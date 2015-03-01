using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface ILiveOrderService
    {
        //För många poster för att ta alla på en gång?
        //IEnumerable<LiveOrder> GetAll();
        IEnumerable<LiveOrder> GetLiveOrdersSince(DateTime date);
        IEnumerable<LiveOrder> Get(int offset = 0, int limit = 1000);

    }
    public class LiveOrderService : ILiveOrderService
    {
        private IUnitOfWork _unitOfWork;
        public LiveOrderService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<LiveOrder> GetLiveOrdersSince(DateTime date)
        {
            return _unitOfWork.LiveOrderRepository.Get(lo => lo.Created < date);
        }
        
        /*//För många poster för att ta alla på en gång?
        public IEnumerable<LiveOrder> GetAll()
        {
            return _unitOfWork.LiveOrderRepository.Get();
        }
        */
        public IEnumerable<LiveOrder> Get(int offset = 0, int limit = 1000)
        {
            return _unitOfWork.LiveOrderRepository.Get().OrderBy(lo => lo.Created).Skip(offset).Take(limit).ToList();
        }
    }
}
