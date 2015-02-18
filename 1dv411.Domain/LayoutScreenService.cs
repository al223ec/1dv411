using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface ILayoutScreenService : IService<LayoutScreen>
    {
    }
    public class LayoutScreenService : ServiceBase, ILayoutScreenService
    {
        public IEnumerable<LayoutScreen> GetAll()
        {
            //För att implementera eager loading, hämta ut object som är specad
            return _unitOfWork.LayoutScreenRepository.Get(null, null, "Screen, Layout").ToList();
        }

        public LayoutScreen GetById(int id)
        {
            return _unitOfWork.LayoutScreenRepository.Get(l => l.Id == id).FirstOrDefault();
        }
    }
}
