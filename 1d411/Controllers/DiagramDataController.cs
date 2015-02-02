using System;
﻿using _1dv411.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1d411.Controllers
{
    [RoutePrefix("diagramdata")]
    public class DiagramDataController : ApiController
    {
        private IDiagramService _service;
        
        public DiagramDataController()
            : this(new DiagramService())
        { }
        public DiagramDataController(IDiagramService service)
        {
            _service = service;
        }

        //[Route("find/{query?}")]
        //[HttpGet]
        //public IHttpActionResult Find(string query)
        //{
        //    return Ok(_service.GetDiagramData(query));
        //}
        [Route("find/{query?}")]
        [HttpGet]
        public IHttpActionResult Find(int? numberOfDays)
        {
            return Ok(_service.GetDiagramData(numberOfDays.Value));
        }

        [Route("week")]
        [HttpGet]
        public IHttpActionResult GetWeek()
        {
            return Ok(_service.GetDiagramDataThisWeek());
        }

        [Route("month")]
        [HttpGet]
        public IHttpActionResult GetMonth()
        {
            return Ok(_service.GetDiagramDataThisMonth());
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
