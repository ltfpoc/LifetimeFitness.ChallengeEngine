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
    public class ChallengeControllerTest
    {
        [TestMethod]
        public async Task GetAllChallenge()
        {
            try
            {


                // Arrange
                ChallengeController controller = new ChallengeController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                // Act
                ChallengeProvider _ChallengeProvider = new ChallengeProvider();
                var testProducts = await _ChallengeProvider.GetAll() as List<Challenge>;
                int testproduct = testProducts.Count;
                // Act
                var response = await controller.GetChallenges() as HttpResponseMessage;
                ObjectContent objContent = response.Content as ObjectContent;
                List<Challenge> picklistItem = objContent.Value as List<Challenge>;
                int icount = picklistItem.Count;

                var response1 = await controller.GetChallengesByCategoryClub(1,5) as HttpResponseMessage;
                ObjectContent objContent1 = response1.Content as ObjectContent;
                List<Challenge> picklistItem1 = objContent1.Value as List<Challenge>;

                
                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(testproduct, icount);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[TestMethod]
        //public async Task GetChallengeById()
        //{
        //    try
        //    {
        //        // Arrange
        //        ChallengeController controller = new ChallengeController();
        //        controller.Request = new HttpRequestMessage();
        //        controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        //        // Act
        //        ChallengeProvider _ChallengeProvider = new ChallengeProvider();
        //        var testProducts = await _ChallengeProvider.GetById(1) as Challenge;
        //        // Act
        //        var response = await controller.GetChallenges(1) as HttpResponseMessage;
        //        ObjectContent objContent = response.Content as ObjectContent;
        //        Challenge picklistItem = objContent.Value as Challenge;
        //        // Assert
        //        Assert.IsNotNull(response);
        //        Assert.AreEqual(testProducts, picklistItem);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        [TestMethod]
        public async Task GetChallangesBYClubCategoryId()
        {
            try
            {
                // Arrange
                ChallengeProvider _ChallengeProvider = new ChallengeProvider();
                var testProducts = await _ChallengeProvider.GetChallanges(1,6) as List<Challenge>;
                int testproduct = testProducts.Count;

                // Assert
                Assert.IsNotNull(testProducts);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [TestMethod]
        public void PostChallenge()
        {
            try
            {
                // Arrange
                ChallengeController controller = new ChallengeController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                Challenge objChallange = new Challenge()
                {
                    Name = "TEST",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Now.AddDays(10),
                    Duration = 10,
                    ChallengeTypeId = 1,
                    ChallengeClubLevelId = 2,
                    IsOganizationLevel = true
                };
                // Act
                var response = controller.PostChallenge(objChallange) as HttpResponseMessage;
                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                Assert.IsNotNull(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
