using _1dv411.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork _unitOfWork; 

        public ServiceBase()
            : this(new UnitOfWork())
        { }
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

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
