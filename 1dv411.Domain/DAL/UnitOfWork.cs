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
        //IRepository<DiagramData> DiagramDataRepository { get; }
        IRepository<Order> OrderRepository { get; }
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
