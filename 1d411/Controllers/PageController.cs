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
    [RoutePrefix("pages")]
    public class PageController : ApiController
    {
        private IServiceFacade _service;

        #region Constructor
        public PageController()
            : this(new ServiceFacade())
        { }
        public PageController(IServiceFacade service)
        {
            _service = service;
        }
        #endregion

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPages()
        {
            return Ok(_service.PageService.GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult FindById(int id)
        {
            return Ok(_service.PageService.GetById(id));
        }

        [Route("names")]
        [HttpGet]
        public IHttpActionResult GetAllPageNames()
        {
            return Ok(_service.PageService.GetAllPageNames());
        }
        
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreatePage(Page page)
        {
            
            _service.PageService.CreatePage(page);
            return Ok(page);
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
