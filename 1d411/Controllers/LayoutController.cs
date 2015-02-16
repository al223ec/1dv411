using _1dv411.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1d411.Controllers
{
    [RoutePrefix("layouts")]
    public class LayoutController : ApiController
    {
        private ILayoutService _service;
        
        public LayoutController()
            : this(new LayoutService())
        { }
        public LayoutController(ILayoutService service)
        {
            _service = service;
        }
        [Route("names")]
        [HttpGet]
        public IHttpActionResult GetAllLayoutNames()
        {
            return Ok(_service.GetAllLayoutNames());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult FindById(int id)
        {
            return Ok(_service.GetLayout(id));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllLayouts()
        {
            return Ok(_service.GetAllLayouts());
        }

    }
}
