using _1dv411.Domain;
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
        private ILayoutService _service;
        
        public PageController()
            : this(new PageService())
        { }
        public PageController(ILayoutService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPages()
        {
            return Ok(_service.GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult FindById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [Route("names")]
        [HttpGet]
        public IHttpActionResult GetAllPageNames()
        {
            return Ok(_service.GetAllPageNames());
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
