using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{

    public interface IServiceFacade : IDisposable 
    {
        IScreenService ScreenService { get; }
        IDiagramService DiagramService { get; }
        IPageService PageService { get; }
        IService<Template> TemplateService { get; }
        ILiveOrderService LiveOrderService { get; }
        ILiveShipmentService LiveShipmentService { get; }
    }
    public class ServiceFacade : IServiceFacade
    {
        private IUnitOfWork _unitOfWork;

        private IScreenService _screenService;
        private IPageScreenService _pageScreenService;
        private IService<Template> _templateService;
        private IDiagramService _diagramService;
        private IPageService _pageService;
        private ILiveOrderService _liveOrderService;
        private ILiveShipmentService _liveShipmentService;

        public IScreenService ScreenService 
        {
            get { return _screenService ?? (_screenService = new ScreenService(_unitOfWork, this.PageService)); }
        }
        public IDiagramService DiagramService
        {
            get { return _diagramService ?? (_diagramService = new DiagramService(_unitOfWork, this.LiveOrderService, this.LiveShipmentService)); }
        }
        public IPageService PageService
        {
            get { return _pageService ?? (_pageService = new PageService(_unitOfWork, this.DiagramService)); }
        }
        public IPageScreenService PageScreenService
        {
            get { return _pageScreenService ?? (_pageScreenService = new PageScreenService(_unitOfWork)); }
        }
        public IService<Template> TemplateService
        {
            get { return _templateService ?? (_templateService = new TemplateService(_unitOfWork)); }
        }

        public ILiveOrderService LiveOrderService
        {
            get { return _liveOrderService ?? (_liveOrderService = new LiveOrderService(_unitOfWork)); }
        }
        public ILiveShipmentService LiveShipmentService
        {
            get { return _liveShipmentService ?? (_liveShipmentService = new LiveShipmentService(_unitOfWork)); }
        }

        #region Construct
        public ServiceFacade()
            : this(new UnitOfWork())
        { }
        public ServiceFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        #endregion

        #region IDisposable
        protected bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
