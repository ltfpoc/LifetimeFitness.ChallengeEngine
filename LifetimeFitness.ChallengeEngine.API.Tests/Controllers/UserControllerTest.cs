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
    public class UserControllerTest
    {
        [TestMethod]
        public  async Task  GetAllUser()
        {
            try
            {
                // Arrange
                UserController controller = new UserController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                
                // Act
                UserProvider _UserProvider = new UserProvider();
                var listUsers = await _UserProvider.GetAll() as List<User>;
                int count = listUsers.Count;
                
                // Act
                var response = await controller.GetUsers() as HttpResponseMessage;
                ObjectContent objContent = response.Content as ObjectContent;
                List<User> picklistItem = objContent.Value as List<User>;
                int icount = picklistItem.Count;
                
                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(count, icount);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [TestMethod]
        public async Task SearchUser()
        {
            try
            {
                // Arrange
                UserController controller = new UserController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

                var response =  await controller.SearchUser("Ltf") as HttpResponseMessage;
                // Assert
                Assert.IsNotNull(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
