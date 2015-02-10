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
        IRepository<LayoutScreen> LayoutScreenRepository { get; }
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

        private IRepository<LayoutScreen> _layoutScreenRepository;
        public IRepository<LayoutScreen> LayoutScreenRepository
        {
            get { return _layoutScreenRepository ?? (_layoutScreenRepository = new Repository<LayoutScreen>(_context)); }
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
