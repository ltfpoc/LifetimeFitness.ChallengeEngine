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
    public class CategoryControllerTest
    {
        [TestMethod]
        public async Task GetAllCategory()
        {
            try
            {


                // Arrange
                CategoryController controller = new CategoryController();
                controller.Request = new HttpRequestMessage();
                controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                // Act
                ChallengeTypeProvider _ChallengeTypeProvider = new ChallengeTypeProvider();
                var testProducts = await _ChallengeTypeProvider.GetAll() as List<ChallengeType>;
                int testproduct = testProducts.Count;
                // Act
                var response = await controller.GetCategory() as HttpResponseMessage;
                ObjectContent objContent = response.Content as ObjectContent;
                List<ChallengeType> picklistItem = objContent.Value as List<ChallengeType>;
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
    }
}
