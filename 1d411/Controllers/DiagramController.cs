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
        [Route("appliaction-stats")]
        [HttpGet]
        public IHttpActionResult GetApplicationStats()
        {
            return Ok(_service.DiagramService.GetApplicationStats());
        }

        /* Metoder för att seeda databsen med diagram-data.*/
        [Route("seed-orders-for/{year:int}/{month:int}")]
        [HttpGet]
        public IHttpActionResult SeedLiveOrdersFor(int year, int month)
        {
            return Ok(_service.DiagramService.SeedLiveOrders(year, month));
        }
        
        //[Route("seed-all-live-orders")]
        //[HttpGet]
        //public IHttpActionResult SeedAllLiveOrders()
        //{
        //    return Ok(_service.DiagramService.SeedLiveOrders(null));
        //}
        
        [Route("seed-shipments-for/{year:int}/{month:int}")]
        [HttpGet]
        public IHttpActionResult SeedLiveShipmentsSinceLastYear(int year, int month)
        {
            return Ok(_service.DiagramService.SeedLiveShipments(year, month));
        }

        //[Route("seed-all-live-shipments")]
        //[HttpGet]
        //public IHttpActionResult SeedAllLiveShipments()
        //{
        //    return Ok(_service.DiagramService.SeedLiveShipments(null));
        //}

        
        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}
