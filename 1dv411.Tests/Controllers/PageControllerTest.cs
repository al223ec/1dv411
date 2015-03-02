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
    public class PageControllerTest
    {
        private IApplicationContext _context;
        private IServiceFacade _service;
        
        public PageControllerTest()
        {
            _context = new TestApplicationContext();
            _service = new ServiceFacade(new UnitOfWork(_context));
        }
        
        [TestMethod]
        public void Get()
        {
            PageController controller = new PageController(_service);
            var result = controller.GetAllPages();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetPages_GetAllPages()
        {
            _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo1"});
            _context.Pages.Add(new Page { Id = 2, TemplateId = 1, Name = "Demo2"});
            _context.Pages.Add(new Page { Id = 3, TemplateId = 1, Name = "Demo3"});
            
            var controller = new PageController(_service);
            var result = controller.GetAllPages() as OkNegotiatedContentResult<IEnumerable<Page>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Count());
        }

        [TestMethod]
        public void GetPage_GetPageById()
        {
            int id = 1;
            _context.Pages.Add(new Page { Id = id, Name = "Demo1" });

            var controller = new PageController(_service);
            var result = controller.FindById(id) as OkNegotiatedContentResult<Page>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, id);
        }

        [TestMethod]
        public void GetPage_GetAllPageNames()
        {
            _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo1" });
            _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo2" });
            _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo3" });

            var controller = new PageController(_service);
            var result = controller.GetAllPageNames() as OkNegotiatedContentResult<IEnumerable<string>>;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostPage_CreatePage()
        {
            var page = _context.Pages.Add(new Page { TemplateId = 1, Name = "Demo1"});
            var controller = new PageController(_service);
           // var result = controller.CreatePage(page) as OkNegotiatedContentResult<Page>;

           // Assert.IsNotNull(result);
        }
    }
}
