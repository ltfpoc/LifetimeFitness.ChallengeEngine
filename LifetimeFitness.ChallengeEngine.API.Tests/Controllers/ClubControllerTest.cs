using LifetimeFitness.ChallengeEngine.API.Controllers;
using LifetimeFitness.ChallengeEngine.Business;
using LifetimeFitness.ChallengeEngine.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace LifetimeFitness.ChallengeEngine.API.Tests.Controllers
{
    [TestClass]
    public class ClubControllerTest
    {
        [TestMethod]
        public async Task GetAllClub()
        {
            try
            {
                // Arrange
                ClubController controller = new ClubController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                // Act
                ClubProvider _ClubProvider = new ClubProvider();
                var testProducts = await _ClubProvider.GetAll() as List<Club>;
                int testproduct = testProducts.Count;
                // Act
                var response = await controller.GetClub() as HttpResponseMessage;
                ObjectContent objContent = response.Content as ObjectContent;
                List<Club> picklistItem = objContent.Value as List<Club>;
                int icount = picklistItem.Count;
                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(testproduct, icount);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [TestMethod]
        public async Task GetClubById()
        {
            try
            {
                // Arrange
                ClubController controller = new ClubController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                // Act
                ClubProvider _ClubProvider = new ClubProvider();
                var testClub = await _ClubProvider.GetById(1) as Club;
                // Act
                var response = await controller.GetClub(1) as HttpResponseMessage;
                ObjectContent objContent = response.Content as ObjectContent;
                var pickClub = objContent.Value as Club;
                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(testClub, pickClub);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
