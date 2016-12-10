using LifetimeFitness.ChallengeEngine.Business;
using LifetimeFitness.ChallengeEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace LifetimeFitness.ChallengeEngine.API.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            await Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            UserProvider _userProvider = new UserProvider();
            UserRoleProvider _userRoleProvider = new UserRoleProvider();
            var entityUser = await _userProvider.LoginUser(context.UserName, context.Password);
            
            if (entityUser == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            else
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = entityUser.UserName,
                    Id = entityUser.UserId.ToString()
                };
            }

            var userrole =  await _userRoleProvider.GetById(entityUser.RoleId.Value);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", userrole.Description));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "firstName", entityUser.FirstName },
                    { "lastName", entityUser.LastName },
                    { "userRole", userrole.Description }
                });
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            //var client = context.OwinContext.Get<ApplicationClient>("oauth:client");

            // var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            // enforce client binding of refresh token
            //if (client.Id != currentClient)
            //{
            //    context.Rejected();
            //    return;
            //}

            // chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
            await  Task.FromResult<object>(null); 
        }
    }
}