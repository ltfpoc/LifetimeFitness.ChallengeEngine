using LifetimeFitness.ChallengeEngine.Business;
using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.Core.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LifetimeFitness.ChallengeEngine.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Enrollment")]
    public class EnrollmentController : ApiController
    {
        UserChallengeEnrollmentProvider _userChallengeEnrollmentProvider = new UserChallengeEnrollmentProvider();
        [Route("PostEnrollment")]
        // POST api/values
        public HttpResponseMessage PostEnrollment([FromBody]Enrollment userChallengeEnrollment)
        {
            try
            {
                _userChallengeEnrollmentProvider.Insert(userChallengeEnrollment);
                return Request.CreateResponse(HttpStatusCode.Created, "Created Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("GetEnrollments")]
        // GET: api/Challenge
        public async Task<HttpResponseMessage> GetEnrollment()
        {
            try
            {
                var entity = await _userChallengeEnrollmentProvider.GetAll();
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Enrollment not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
