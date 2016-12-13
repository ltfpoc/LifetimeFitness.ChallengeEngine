using LifetimeFitness.ChallengeEngine.Business;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LifetimeFitness.ChallengeEngine.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Club")]
    public class ClubController : ApiController
    {
        ClubProvider _ClubProvider = new ClubProvider();
        //[Authorize]
        [Route("GetClub")]
        // GET: api/Club
        public async Task<HttpResponseMessage> GetClub()
        {
            try
            {
                var entity = await _ClubProvider.GetAll();
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Club not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Authorize]
        [Route("GetClubId")]
        // GET: api/Club/5
        public async Task<HttpResponseMessage> GetClub(int id)
        {
            try
            {
                var entity =await _ClubProvider.GetById(id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Club with " + id + "not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //public HttpResponseMessage GetCategoryByClub(int id)
        //{
        //    try
        //    {
        //        var entiry = _ClubProvider.FindBy(a=>a.ClubId==id);
        //        if (entiry != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entiry);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Club with " + id + "not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

    }
}
