using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface ILiveShipmentService
    {
        IEnumerable<LiveShipment> GetLiveShipmentsSince(DateTime? limitByDate = null);
        IEnumerable<LiveShipment> Get(int offset = 0, int limit = 1000);

    }
    public class LiveShipmentService : ILiveShipmentService
    {
        private IUnitOfWork _unitOfWork;
        public LiveShipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<LiveShipment> GetLiveShipmentsSince(DateTime? limitByDate = null)
        {
            Expression<Func<LiveShipment, bool>> dateFilter = null;
            if (limitByDate != null)
            {
                dateFilter = ls => ls.PostingDate >= limitByDate.Value;
            }
            return _unitOfWork.LiveShipmentRepository.Get(dateFilter, null, null, null);
        }

        public IEnumerable<LiveShipment> Get(int offset = 0, int limit = 1000)
        {
            
            return _unitOfWork.LiveShipmentRepository.Get(null, q => q.OrderBy(ls => ls.PostingDate), offset, limit);
        }
    }
}
