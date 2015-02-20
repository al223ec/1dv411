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
        IRepository<Screen> ScreenRepository { get; }
        IRepository<PageScreen> PageScreenRepository { get; }
        IRepository<Page> PageRepository { get; }
        IRepository<Text> TextRepository { get; }
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        private IRepository<Order> _orderRepository;
        public IRepository<Order> OrderRepository
        {
            get { return _orderRepository ?? (_orderRepository = new Repository<Order>(_context)); }
        }

        private IRepository<Screen> _screenRepository; 
        public IRepository<Screen> ScreenRepository
        {
            get { return _screenRepository ?? (_screenRepository = new Repository<Screen>(_context)); }
        }

        private IRepository<PageScreen> _pageScreenRepository;
        public IRepository<PageScreen> PageScreenRepository
        {
            get { return _pageScreenRepository ?? (_pageScreenRepository = new Repository<PageScreen>(_context)); }
        }


        private IRepository<Page> _pageRepository;
        public IRepository<Page> PageRepository
        {
            get { return _pageRepository ?? (_pageRepository = new Repository<Page>(_context)); }
        }

        private IRepository<Text> _textRepository;
        public IRepository<Text> TextRepository
        {
            get { return _textRepository ?? (_textRepository = new Repository<Text>(_context)); }
        }

        public UnitOfWork()
            : this(new ApplicationContext())
        { }
        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext; 
        }

        public void Save()
        {
            throw new NotImplementedException();
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
