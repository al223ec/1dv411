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

        /* Metoder för att seeda databsen med diagram-data.*/
        [Route("seed-orders-since-last-year")]
        [HttpGet]
        public IHttpActionResult SeedLiveOrdersSinceLastYear()
        {
            DateTime now = new DateTime();
            DateTime lastYear = new DateTime(now.Year-1,1,1);
            return Ok("number of orders added: " + _service.DiagramService.SeedLiveOrders(lastYear));
        }

        [Route("seed-all-live-orders")]
        [HttpGet]
        public IHttpActionResult SeedAllLiveOrders()
        {
            return Ok("number of orders added: " + _service.DiagramService.SeedLiveOrders(null));
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
