using _1dv411.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1d411.Controllers
{
    [RoutePrefix("screens")]
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

        [Route("layouts/{screenId:int}")]
        [HttpGet]
        public IHttpActionResult FindLayoutsByScreenId(int screenId)
        {
            return Ok(_service.GetLayoutsWithScreenId(screenId));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllScreens()
        {
            return Ok(_service.GetAllScreens());
        }
    }
}
