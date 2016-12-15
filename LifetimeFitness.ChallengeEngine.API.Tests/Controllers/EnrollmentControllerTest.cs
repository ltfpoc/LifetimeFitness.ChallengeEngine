using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using LifetimeFitness.ChallengeEngine.API.Controllers;
using System.Net.Http;
using LifetimeFitness.ChallengeEngine.Business;
using System.Web.Http.Hosting;
using System.Web.Http;
using LifetimeFitness.ChallengeEngine.Core;
using System.Collections.Generic;
using System.Net;

namespace LifetimeFitness.ChallengeEngine.API.Tests.Controllers
{
    [TestClass]
    public class EnrollmentControllerTest
    {
        [TestMethod]
        public void PostChallenge()
        {
            try
            {
                //// Arrange
                //EnrollmentController controller = new EnrollmentController();
                //controller.Request = new HttpRequestMessage();
                //controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                //UserChallengeEnrollment objEnrollment = new UserChallengeEnrollment()
                //{
                //   UserId=2,
                //   ChallengeId=2,
                //   ChallengeClubRelationId=2
                //};
                //// Act
                //var response = controller.PostEnrollment(objEnrollment) as HttpResponseMessage;
                //// Assert
                //Assert.IsNotNull(response);
                //Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                //Assert.IsNotNull(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
