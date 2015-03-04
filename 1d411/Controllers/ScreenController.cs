using _1d411.ViewModel;
using _1dv411.Domain;
using _1dv411.Domain.DbEntities;
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

        #region Constructor
        public ScreenController()
            : this(new ServiceFacade())
        { }
        public ScreenController(IServiceFacade service)
        {
            _service = service;
        }
        #endregion

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

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostScreen(ScreenViewModel screenViewModel)
        {
            var screen = screenViewModel.Screen;
            screen.PageScreens = screen.PageScreens != null ? screen.PageScreens : new List<PageScreen>();

            if( screenViewModel.Pages != null)
            { 
                foreach (var page in screenViewModel.Pages)
	            {
			        screen.PageScreens.Add(new PageScreen{
                        Screen = screen,
                        Page = page,
                    });
			    }
            }
            _service.ScreenService.Save(screenViewModel.Screen);
            return Ok(screen);
        }

        [Route("{id:int}/delete")]
        [HttpPost]
        public IHttpActionResult DeleteScreen(int id)
        {
            return Ok(_service.ScreenService.Delete(id));
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
