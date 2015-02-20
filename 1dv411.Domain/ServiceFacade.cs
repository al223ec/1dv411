using _1dv411.Domain.DAL;
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
        IPageScreenService PageScreenService { get; }
    }
    public class ServiceFacade : IServiceFacade
    {
        private IUnitOfWork _unitOfWork;

        private IScreenService _screenService; 
        public IScreenService ScreenService 
        {
            get { return _screenService ?? (_screenService = new ScreenService(_unitOfWork, this.PageService)); }
        }

        private IDiagramService _diagramService; 
        public IDiagramService DiagramService
        {
            get { return _diagramService ?? (_diagramService = new DiagramService(_unitOfWork)); }
        }

        private IPageService _pageService; 
        public IPageService PageService
        {
            get { return _pageService ?? (_pageService = new PageService(_unitOfWork, this.DiagramService)); }
        }


        private IPageScreenService _pageScreenService; 
        public IPageScreenService PageScreenService
        {
            get { return _pageScreenService ?? (_pageScreenService = new PageScreenService(_unitOfWork)); }
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
