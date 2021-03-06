﻿using System.Web;
using _1dv411.Domain;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _1d411.ViewModel;
using Newtonsoft.Json;

namespace _1d411.Controllers
{
    [RoutePrefix("pages")]
    public class PageController : ApiController
    {
        private IServiceFacade _service;

        #region Constructor
        public PageController()
            : this(new ServiceFacade())
        { }
        public PageController(IServiceFacade service)
        {
            _service = service;
        }
        #endregion

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPages()
        {
            return Ok(_service.PageService.GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult FindById(int id)
        {
            return Ok(_service.PageService.GetById(id));
        }

        [Route("names")]
        [HttpGet]
        public IHttpActionResult GetAllPageNames()
        {
            return Ok(_service.PageService.GetAllPageNames());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreatePage(PageViewModel pageViewModel)
        {
            var page = pageViewModel.Page;
            page.Partials = new List<Partial>();
            for (int i = 0; i < pageViewModel.Partials.Count; i++)
            {
                if (pageViewModel.Partials[i].PartialType == "Diagram")
                {
                    Diagram diagram = new Diagram
                    {
                        DiagramType = pageViewModel.Partials[i].DiagramType,
                        Position = pageViewModel.Partials[i].Position
                    };
                    page.Partials.Add(diagram);
                }
                else if (pageViewModel.Partials[i].PartialType == "Text")
                {
                    Text text = new Text 
                    {
                        Content = pageViewModel.Partials[i].Content,
                        Position = pageViewModel.Partials[i].Position,
                        Align = pageViewModel.Partials[i].Align,
                        Valign = pageViewModel.Partials[i].Valign,
                        FontSize = pageViewModel.Partials[i].FontSize,
                        Bold = pageViewModel.Partials[i].Bold,
                        Italic = pageViewModel.Partials[i].Italic
                    };
                    page.Partials.Add(text);
                }
                else if (pageViewModel.Partials[i].PartialType == "Image")
                {
                    Image image = new Image
                    {
                        Url = pageViewModel.Partials[i].Url,
                        Position = pageViewModel.Partials[i].Position
                    };
                    page.Partials.Add(image);
                }
            }

            _service.PageService.CreatePage(page);
            
            return Ok(page);
        }

        [Route("{id:int}/delete")]
        [HttpPost]
        public IHttpActionResult DeletePage(int id)
        {
            return Ok(_service.PageService.Delete(id));
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