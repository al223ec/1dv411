using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1d411.Controllers;

namespace _1dv411.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AppController controller = new AppController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
    }
}
