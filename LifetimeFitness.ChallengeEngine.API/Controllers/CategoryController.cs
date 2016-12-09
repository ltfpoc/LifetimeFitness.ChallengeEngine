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
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        ChallengeTypeProvider _ChallengeTypeProvider = new ChallengeTypeProvider();
        [Route("GetCategory")]
        // GET: api/Category 
        public async Task<HttpResponseMessage> GetCategory()
        {
            try
            {
                var entity = await _ChallengeTypeProvider.GetAll();
                if (entity != null)
                {
                    return  Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("GetCategoryById")]
        // GET: api/Category/5
        public async Task<HttpResponseMessage> GetCategoryById(int id)
        {
            try
            {
                var entity = await _ChallengeTypeProvider.GetById(id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category with " + id + "not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //// POST: api/Category
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Category/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Category/5
        //public void Delete(int id)
        //{
        //}
    }
}
