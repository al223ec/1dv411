using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    class TemplateService : IService<Template>
    {
        private IUnitOfWork _unitOfWork;

        #region Constructor
        public TemplateService(DAL.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public IEnumerable<Template> GetAll()
        {
            return _unitOfWork.TemplateRepository.Get();  
        }

        public Template GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
