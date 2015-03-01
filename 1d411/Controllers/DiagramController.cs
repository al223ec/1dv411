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

        #region Constructor
        public DiagramController()
            : this(new ServiceFacade())
        { }
        public DiagramController(IServiceFacade service)
        {
            _service = service;
        }
        #endregion

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetDataWithDiagramId(int id)
        {
            return Ok(_service.DiagramService.GetDataWithDiagramId(id));
        }

        /* Testmetod för att seeda databsen med några äkta ordrar.*/
        [Route("seed-order-table-from-live-orders")]
        [HttpGet]
        public IHttpActionResult SeedOrdersFromLiveOrders()
        {
            return Ok("number of orders added: " + _service.DiagramService.SeedLiveOrders());
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
