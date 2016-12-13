using LifetimeFitness.ChallengeEngine.Business;
using LifetimeFitness.ChallengeEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace LifetimeFitness.ChallengeEngine.API.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        UserProvider _userProvider = new UserProvider();

        [Route("GetUsers")]
        public async Task<HttpResponseMessage> GetUsers()
        {
            try
            {
                var entity = await _userProvider.GetAllUsers();
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("RegisterUser")]
        public HttpResponseMessage RegisterUser([FromBody]User usertoregister)
        {
            try
            {

                var entity = _userProvider.RegisterUser(usertoregister);
                if (entity == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("SearchUser")]
        public async Task<HttpResponseMessage> SearchUser(string userName)
        {
            try
            {
                var entity = await _userProvider.GetAllBy(u => u.FirstName.Contains(userName) || u.LastName.Contains(userName));
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("GetUsers/Challenge/{challengeId}/Club/{clubId}")]
        public async Task<HttpResponseMessage> GetUsers(int ChallengeId, int ClubId)
        {
            try
            {
                var entity = await _userProvider.GetUsersNotInChallenge(ChallengeId,ClubId);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
