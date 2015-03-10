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
    public class TemplateControllerTest
    {
        private IApplicationContext _context;
        private IServiceFacade _service;

        public TemplateControllerTest()
        {
            _context = new TestApplicationContext();
            _service = new ServiceFacade(new UnitOfWork(_context));
        }

        [TestMethod]
        public void Get()
        {
            TemplateController controller = new TemplateController(_service);
            var result = controller.GetAllTemplates();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetAll()
        {
            var template1 = GetDemoTemplate(1);
            var template2 = GetDemoTemplate(2);
            var template3 = GetDemoTemplate(3); 
            
            _context.Templates.Add(template1);
            _context.Templates.Add(template2);
            _context.Templates.Add(template3);
 
            TemplateController controller = new TemplateController(_service);
            var result = controller.GetAllTemplates() as OkNegotiatedContentResult<IEnumerable<Template>>;
            Assert.IsNotNull(result);

            Assert.AreEqual(result.Content.ElementAt(0), template1);
            Assert.AreEqual(result.Content.ElementAt(1), template2);
            Assert.AreEqual(result.Content.ElementAt(2), template3);
        }

        [TestMethod]
        public void PostTemplate_CreateTemplate()
        {
            var template = GetDemoTemplate();  
            var controller = new TemplateController(_service);
            int numberOfTemplates = _context.Templates.Count(); 
            var result = controller.PostTemplate(template) as OkNegotiatedContentResult<Template>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, template);
            Assert.AreEqual(numberOfTemplates + 1, _context.Templates.Count()); 

        }

        private Template GetDemoTemplate(int id = 1)
        {
            return new Template { Name = "Demo1", Id = id, NumberOfPartials = 3, FileName = "filename.html" };
        }

    }
}
