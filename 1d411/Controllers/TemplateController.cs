using _1dv411.Domain;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1d411.Controllers
{
    [RoutePrefix("templates")]
    public class TemplateController : ApiController
    {
        private IServiceFacade _service;

        #region Constructor
        public TemplateController()
            : this(new ServiceFacade())
        { }
        public TemplateController(IServiceFacade service)
        {
            _service = service;
        }
        #endregion

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTemplates()
        {
            return Ok(_service.TemplateService.GetAll());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostTemplate(Template template)
        {
            _service.PageService.SaveTemplate(template);
            return Ok(template);
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}
