﻿using LifetimeFitness.ChallengeEngine.Business;
using LifetimeFitness.ChallengeEngine.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LifetimeFitness.ChallengeEngine.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Challenge")]
    public class ChallengeController : ApiController
    {
        ChallengeProvider _ChallengeProvider = new ChallengeProvider();
        ChallengeClubRelationProvider _ChallengeClubRelationProvider = new ChallengeClubRelationProvider();


       [Route("GetChallenges")]
        // GET: api/Challenge
        public async Task<HttpResponseMessage> GetChallenges()
        {
            try
            {
                var entity = await _ChallengeProvider.GetAll();
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Challenge not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("GetChallenges/Category/{categoryid}/Club/{clubid}")]
        public async Task<HttpResponseMessage> GetChallengesByCategoryClub(int categoryid, int clubid)
        {
            try
            {
                var entity = await _ChallengeProvider.GetChallanges(categoryid, clubid);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Challenge not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("GetChallenges/{id}")]
        // GET: api/Challenge/5
        public async Task<HttpResponseMessage> GetChallenges(int id)
        {
            try
            {
                var entity = await _ChallengeProvider.GetById(id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Challenge with " + id + "not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("PostChallenge")]
        public HttpResponseMessage PostChallenge([FromBody]Challenge challenge)
        {
            try
            {
                _ChallengeProvider.Insert(challenge);
                return Request.CreateResponse(HttpStatusCode.Created, "Created Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("GetChallengeClubRelationship/Club/{clubid}/Challenge/{challengeId}")]
        public async Task<HttpResponseMessage> GetChallengeClubRelationship(int clubId, int challengeId)
        {
            try
            {
                var entity = await _ChallengeClubRelationProvider.GetChallengeClubRelationship(clubId, challengeId);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ChallengeClubRelationship not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
