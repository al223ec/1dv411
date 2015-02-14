using _1dv411.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1d411.Controllers
{
    [RoutePrefix("screenlayout")]
    public class ScreenController : ApiController
    {
        private ILayoutScreenService _service;
        
        public ScreenController()
            : this(new LayoutScreenService())
        { }
        public ScreenController(ILayoutScreenService service)
        {
            _service = service;
        }
        [Route("layout/{id:int}")]
        [HttpGet]
        public IHttpActionResult FindById(int id)
        {
            return Ok(_service.GetLayout(id));
        }

        [Route("layouts")]
        [HttpGet]
        public IHttpActionResult GetAllLayouts()
        {
            return Ok(_service.GetAllLayouts());
        }

        [Route("screen/{screenId:int}")]
        [HttpGet]
        public IHttpActionResult FindLayoutsByScreenId(int screenId)
        {
            return Ok(_service.GetLayoutsWithScreenId(screenId));
        }
    }
}
