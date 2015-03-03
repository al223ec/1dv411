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
using _1d411.ViewModel;


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
            var demo0 = _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo1"});
            var demo1 = _context.Pages.Add(new Page { Id = 2, TemplateId = 1, Name = "Demo2" });
            var demo2 = _context.Pages.Add(new Page { Id = 3, TemplateId = 1, Name = "Demo3" });
            

            var controller = new PageController(_service);
            var result = controller.GetAllPages() as OkNegotiatedContentResult<IEnumerable<Page>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Count());
            Assert.AreEqual(result.Content.ElementAt(0), demo0);
            Assert.AreEqual(result.Content.ElementAt(1), demo1);
            Assert.AreEqual(result.Content.ElementAt(2), demo2);
        }

        [TestMethod]
        public void GetPage_GetPageById()
        {
            int id = 1;
            var demo0 = _context.Pages.Add(new Page { Id = id, Name = "Demo1" });

            var controller = new PageController(_service);
            var result = controller.FindById(id) as OkNegotiatedContentResult<Page>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, id);
            Assert.AreEqual(result.Content.Name, demo0.Name);
        }

        [TestMethod]
        public void GetPage_GetAllPageNames()
        {
            var demo0 = _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo1" });
            var demo1 = _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo2" });
            var demo2 = _context.Pages.Add(new Page { Id = 1, TemplateId = 1, Name = "Demo3" });

            var controller = new PageController(_service);
            var result = controller.GetAllPageNames() as OkNegotiatedContentResult<IEnumerable<string>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.ElementAt(0), demo0.Name);
            Assert.AreEqual(result.Content.ElementAt(1), demo1.Name);
            Assert.AreEqual(result.Content.ElementAt(2), demo2.Name);
        }

        [TestMethod]
        public void PostPage_CreatePage()
        {
            var controller = new PageController(_service);
            var page = _context.Pages.Add(new Page { TemplateId = 1, Name = "page1" });
            
            List<TextContent> listText = new List<TextContent>();            
            Text text = new Text
            {
                TextContents = listText
            };
            
            var textContent = _context.TextContents.Add(new TextContent { Content = "hej", TextId = 1, Text = text, TextType = TextType.Heading });
            listText.Add(textContent);
            
            PartialViewModel pvm = new PartialViewModel
            {
                PartialType = "Text",
                Position = 1,
                TextContents = listText

            };
            
            List<PartialViewModel> partialViewModelList = new List<PartialViewModel>();
            partialViewModelList.Add(pvm);
            
            PageViewModel svm = new PageViewModel
            {
                Page = page,
                Partials = partialViewModelList
            };

            var result = controller.CreatePage(svm) as OkNegotiatedContentResult<Page>;
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, page);
            Assert.AreEqual(result.Content.Name, page.Name);
        }
    }
}
