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
        IEnumerable<Order> GetAllLiveOrders();
        IEnumerable<Order> GetNewLiveOrders();
    }
    public class LiveOrderRepository : ILiveOrderRepository
    {
        private ILiveOrdersContext _context;
        private DbSet<Order> _set;
        public LiveOrderRepository(ILiveOrdersContext context)
        {
            _context = context;
            _set = _context.Set<Order>();
        }

        public IEnumerable<Order> GetAllLiveOrders()
        {
            IQueryable<Order> query = _set;
            return query.ToList();
        }

        public IEnumerable<Order> GetNewLiveOrders()
        {
            throw new NotImplementedException();
        }
    }
}
