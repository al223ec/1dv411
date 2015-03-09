using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> OrderRepository { get; }
        IRepository<Shipment> ShipmentRepository { get; }
        IRepository<Screen> ScreenRepository { get; }
        IRepository<PageScreen> PageScreenRepository { get; }
        IRepository<Page> PageRepository { get; }
        IRepository<Text> TextRepository { get; }
        IRepository<Diagram> DiagramRepository { get; }
        IRepository<Template> TemplateRepository { get; }

        ILiveOrderRepository LiveOrderRepository { get; }
        ILiveShipmentRepository LiveShipmentRepository { get; }
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private IApplicationContext _context;
        private ILiveOrdersContext _liveOrdersContext;
        private ILiveShipmentsContext _liveShipmentsContext;

        private IRepository<Order> _orderRepository;
        private IRepository<Shipment> _shipmentRepository;
        private IRepository<Screen> _screenRepository; 
        private IRepository<PageScreen> _pageScreenRepository;
        private IRepository<Page> _pageRepository;
        private IRepository<Text> _textRepository;
        private IRepository<Diagram> _diagramRepository;
        private IRepository<Template> _templateRepository;

        private ILiveOrderRepository _liveOrderRepository;
        private ILiveShipmentRepository _liveShipmentRepository;


        public IRepository<Order> OrderRepository
        {
            get { return _orderRepository ?? (_orderRepository = new Repository<Order>(_context)); }
        }
        public IRepository<Shipment> ShipmentRepository
        {
            get { return _shipmentRepository ?? (_shipmentRepository = new Repository<Shipment>(_context)); }
        }
        public IRepository<Screen> ScreenRepository
        {
            get { return _screenRepository ?? (_screenRepository = new Repository<Screen>(_context)); }
        }
        public IRepository<PageScreen> PageScreenRepository
        {
            get { return _pageScreenRepository ?? (_pageScreenRepository = new Repository<PageScreen>(_context)); }
        }
        public IRepository<Page> PageRepository
        {
            get { return _pageRepository ?? (_pageRepository = new Repository<Page>(_context)); }
        }
        public IRepository<Text> TextRepository
        {
            get { return _textRepository ?? (_textRepository = new Repository<Text>(_context)); }
        }
        public IRepository<Diagram> DiagramRepository
        {
            get { return _diagramRepository ?? (_diagramRepository = new Repository<Diagram>(_context)); }
        }
        public IRepository<Template> TemplateRepository
        {
            get { return _templateRepository ?? (_templateRepository = new Repository<Template>(_context)); }
        }

        public ILiveOrderRepository LiveOrderRepository
        {
            get { return _liveOrderRepository ?? (_liveOrderRepository = new LiveOrderRepository(_liveOrdersContext)); }
        }
        public ILiveShipmentRepository LiveShipmentRepository
        {
            get { return _liveShipmentRepository ?? (_liveShipmentRepository = new LiveShipmentRepository(_liveShipmentsContext)); }
        }


        #region Constructor
        public UnitOfWork()
            : this(new ApplicationContext(), new LiveOrdersContext(), new LiveShipmentsContext())
        { }
        public UnitOfWork(IApplicationContext dbContext)
        {
            _context = dbContext;
            _liveOrdersContext = null;
            _liveShipmentsContext = null;
        }
        public UnitOfWork(IApplicationContext dbContext, ILiveOrdersContext liveOrdersContext, ILiveShipmentsContext liveShipmentsContext)
        {
            _context = dbContext;
            _liveOrdersContext = liveOrdersContext;
            _liveShipmentsContext = liveShipmentsContext;
        }

        #endregion

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   _context.Dispose();
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
