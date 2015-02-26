using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1d411.Controllers;
using _1dv411.Domain;
using _1dv411.Domain.DAL;
using _1dv411.Tests.Domain.DAL;

namespace _1dv411.Tests.Controllers
{
    [TestClass]
    public class ScreenControllerTest
    {
        private IServiceFacade _service = new ServiceFacade(new UnitOfWork(new TestApplicationContext()));
        [TestMethod]
        public void Get()
        {
            ScreenController controller = new ScreenController(_service);
            var result = controller.GetAllScreens();

              // Assert
            Assert.IsNotNull(result);
              //Assert.AreEqual(2, result.Count());
              //Assert.AreEqual("value1", result.ElementAt(0));
              //Assert.AreEqual("value2", result.ElementAt(1));
        }

        //[TestMethod]
        //public void GetById()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    string result = controller.Get(5);

        //    // Assert
        //    Assert.AreEqual("value", result);
        //}

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}
