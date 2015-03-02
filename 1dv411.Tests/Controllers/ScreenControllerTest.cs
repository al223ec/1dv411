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
using _1dv411.Domain.DbEntities;
using System.Web.Http.Results;

namespace _1dv411.Tests.Controllers
{
    [TestClass]
    public class ScreenControllerTest
    {
        private IApplicationContext _context;
        private IServiceFacade _service;
        
        public ScreenControllerTest()
        {
            _context = new TestApplicationContext();
            _service = new ServiceFacade(new UnitOfWork(_context));
        }
        
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
        [TestMethod]
        public void GetScreens_ShouldReturnAllScreens()
        {
            var demo0 = _context.Screens.Add(new Screen { Id = 1, Name = "Demo1" });
            var demo1 = _context.Screens.Add(new Screen { Id = 2, Name = "Demo2" });
            var demo2 = _context.Screens.Add(new Screen { Id = 3, Name = "Demo3" });

            var controller = new ScreenController(_service);
            var result = controller.GetAllScreens() as OkNegotiatedContentResult<IEnumerable<Screen>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Count());
            Assert.AreEqual(result.Content.ElementAt(0), demo0);
            Assert.AreEqual(result.Content.ElementAt(1), demo1);
            Assert.AreEqual(result.Content.ElementAt(2), demo2);
        }
        [TestMethod]
        public void GetScreens_GetScreenById()
        {
            int id = 1; 
            _context.Screens.Add(new Screen { Id = id, Name = "Demo1" });

            var controller = new ScreenController(_service);
            var result = controller.FindById(id) as OkNegotiatedContentResult<Screen>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, id);
        }
        private Screen GetTestScreen(int id = 1)
        {
            return new Screen() { Id = 3, Name = "Test namn" };
        }

        [TestMethod]
        public void PostScreen_CreateScreen()
        {
            var screen = _context.Screens.Add(new Screen {Name = "Demo1", Timer = 10000 });
            var controller = new ScreenController(_service);
            var result = controller.PostScreen(screen) as OkNegotiatedContentResult<Screen>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, screen);
        }

        [TestMethod]
        public void GetScreens_FindPagesByScreenId()
        {
            int id = 1;
            var screen = _context.Screens.Add(new Screen { Id = id, Name = "Demo1", Timer = 10000 });
            var page = _context.Pages.Add(new Page { Id = id, Name = "Page1" });
            _context.PageScreens.Add(new PageScreen { Id = id, PageId = id, ScreenId = id, Screen = screen, Page = page });

            var controller = new ScreenController(_service);
            var result = controller.FindPagesByScreenId(id) as OkNegotiatedContentResult<IEnumerable<Page>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.ElementAt(0), page);
        }

        //[TestMethod]
        //public void PostProduct_ShouldReturnSameProduct()
        //{
        //    var controller = new ProductController(new TestStoreAppContext());

        //    var item = GetDemoProduct();

        //    var result =
        //        controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(result.RouteName, "DefaultApi");
        //    Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
        //    Assert.AreEqual(result.Content.Name, item.Name);
        //}

        //[TestMethod]
        //public void PutProduct_ShouldReturnStatusCode()
        //{
        //    var controller = new ProductController(new TestStoreAppContext());

        //    var item = GetDemoProduct();

        //    var result = controller.PutProduct(item.Id, item) as StatusCodeResult;
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        //    Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        //}

        //[TestMethod]
        //public void PutProduct_ShouldFail_WhenDifferentID()
        //{
        //    var controller = new ProductController(new TestStoreAppContext());

        //    var badresult = controller.PutProduct(999, GetDemoProduct());
        //    Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        //}

        //[TestMethod]
        //public void GetProduct_ShouldReturnProductWithSameID()
        //{
        //    var context = new TestStoreAppContext();
        //    context.Products.Add(GetDemoProduct());

        //    var controller = new ProductController(context);
        //    var result = controller.GetProduct(3) as OkNegotiatedContentResult<Product>;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(3, result.Content.Id);
        //}

        //[TestMethod]
        //public void GetProducts_ShouldReturnAllProducts()
        //{
        //    var context = new TestStoreAppContext();
        //    context.Products.Add(new Product { Id = 1, Name = "Demo1", Price = 20 });
        //    context.Products.Add(new Product { Id = 2, Name = "Demo2", Price = 30 });
        //    context.Products.Add(new Product { Id = 3, Name = "Demo3", Price = 40 });

        //    var controller = new ProductController(context);
        //    var result = controller.GetProducts() as TestProductDbSet;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(3, result.Local.Count);
        //}

        //[TestMethod]
        //public void DeleteProduct_ShouldReturnOK()
        //{
        //    var context = new TestStoreAppContext();
        //    var item = GetDemoProduct();
        //    context.Products.Add(item);

        //    var controller = new ProductController(context);
        //    var result = controller.DeleteProduct(3) as OkNegotiatedContentResult<Product>;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(item.Id, result.Content.Id);
        //}
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
