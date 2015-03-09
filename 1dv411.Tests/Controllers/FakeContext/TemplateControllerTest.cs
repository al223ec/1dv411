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
    }
}
