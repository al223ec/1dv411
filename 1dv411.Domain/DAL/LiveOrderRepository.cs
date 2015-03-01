using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace _1dv411.Domain.DAL
{
    public interface ILiveOrderRepository
    {
        IEnumerable<LiveOrder> GetAllLiveOrders();
        IEnumerable<LiveOrder> GetNewLiveOrders(DateTime lastLiveOrderDate);
    }
    public class LiveOrderRepository : ILiveOrderRepository
    {
        private ILiveOrdersContext _context;
        private DbSet<LiveOrder> _set;
        public LiveOrderRepository(ILiveOrdersContext context)
        {
            _context = context;
            _set = _context.Set<LiveOrder>();
        }

        public IEnumerable<LiveOrder> GetAllLiveOrders()
        {
            IQueryable<LiveOrder> query = _set;
            return query.ToList();
        }

        public IEnumerable<LiveOrder> GetNewLiveOrders(DateTime lastLiveOrderDate)
        {
            IQueryable<LiveOrder> query = _set;
            return query.Where(lo => lo.Created > lastLiveOrderDate); ;
        }
    }
}
