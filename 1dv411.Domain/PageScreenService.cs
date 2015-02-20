using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IPageScreenService : IService<PageScreen>
    {
    }
    public class PageScreenService :  IPageScreenService
    {
        private IUnitOfWork _unitOfWork;
        public PageScreenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PageScreen> GetAll()
        {
            //För att implementera eager loading, hämta ut object som är specad
            return _unitOfWork.PageScreenRepository.Get(null, null, "Screen, Page").ToList();
        }

        public PageScreen GetById(int id)
        {
            return _unitOfWork.PageScreenRepository.Get(l => l.Id == id).FirstOrDefault();
        }
    }
}
