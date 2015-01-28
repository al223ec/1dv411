using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        /*
        private IRepository<DiagramData> _diagramDataRepository; 
        public IRepository<DiagramData> DiagramDataRepository
        {
            get { return _diagramDataRepository ?? (_diagramDataRepository = new Repository<DiagramData>(_context)); }
        }
        */
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
                   // _context.Dispose();
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
