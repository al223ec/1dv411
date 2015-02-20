using _1dv411.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1d411.Controllers
{
    [RoutePrefix("diagrams")]
    public class DiagramController : ApiController
    {
        private IServiceFacade _service;
        
        public DiagramController()
            : this(new ServiceFacade())
        { }
        public DiagramController(IServiceFacade service)
        {
            _service = service;
        }
        
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetDataWithDiagramId(int id)
        {
            return Ok(_service.DiagramService.GetDataWithDiagramId(id));
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
