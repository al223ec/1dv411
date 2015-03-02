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
        IEnumerable<LiveOrder> Get(
            Expression<Func<LiveOrder, bool>> filter = null,
            Func<IQueryable<LiveOrder>, IOrderedQueryable<LiveOrder>> orderBy = null,
            int? offset = 0,
            int? limit = 1000);
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

        public IEnumerable<LiveOrder> Get(
            Expression<Func<LiveOrder,bool>> filter = null,
            Func<IQueryable<LiveOrder>, IOrderedQueryable<LiveOrder>> orderBy = null,
            int? offset = 0,
            int? limit = 1000)
        {
            IQueryable<LiveOrder> query = _set;
            if (filter != null) { query = query.Where(filter); }
            if (orderBy != null) { query = orderBy(query); }
            if (offset != null ) { query = query.Skip(offset.Value); }
            if (limit != null) { query = query.Take(limit.Value); }
            return query.ToList();
        }
    }
}
