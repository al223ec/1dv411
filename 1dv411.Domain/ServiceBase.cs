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
    }
}
