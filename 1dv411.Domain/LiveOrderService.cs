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
        IEnumerable<LiveOrder> GetAll();
        IEnumerable<LiveOrder> GetLiveOrdersSince(DateTime date);

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
            return _unitOfWork.LiveOrderRepository.GetNewLiveOrders(date);
        }

        public IEnumerable<LiveOrder> GetAll()
        {
            return _unitOfWork.LiveOrderRepository.GetAllLiveOrders();
        }
    }
}
