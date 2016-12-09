using LifetimeFitness.ChallengeEngine.Business;
using LifetimeFitness.ChallengeEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace LifetimeFitness.ChallengeEngine.API.Controllers
{
    public class LoginController : ApiController
    {
        UserProvider _userProvider = new UserProvider();
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("LoginUser")]
        public async Task<IHttpActionResult> LoginUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //IdentityResult result = await _userProvider.RegisterUser(user);

            //IHttpActionResult errorResult = GetErrorResult(result);

            //if (errorResult != null)
            //{
            //    return errorResult;
            //}

            return Ok();
        }
        
        // GET api/<controller>
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}