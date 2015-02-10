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
        private IScreenService _service;
        
        public ScreenController()
            : this(new ScreenService())
        { }
        public ScreenController(IScreenService service)
        {
            _service = service;
        }
        [Route("get/layout/{query?}")]
        [HttpGet]
        public IHttpActionResult find(int? id)
        {
            return Ok(_service.GetLayout(id.Value));
        }


        [Route("find/")]
        [HttpGet]
        public IHttpActionResult Find()
        {
            return Ok(_service.GetLayoutScreens());
        }
        

    }
}
