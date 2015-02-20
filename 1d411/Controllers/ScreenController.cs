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
        private IServiceFacade _service;
        
        public ScreenController()
            : this(new ServiceFacade())
        { }
        public ScreenController(IServiceFacade service)
        {
            _service = service;
        }

        [Route("{screenId:int}/pages")]
        [HttpGet]
        public IHttpActionResult FindPagesByScreenId(int screenId)
        {
            return Ok(_service.ScreenService.GetPagesWithScreenId(screenId));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllScreens()
        {
            return Ok(_service.ScreenService.GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult FindById(int id)
        {
            return Ok(_service.ScreenService.GetById(id));
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
