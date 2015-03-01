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
            string includeProperties = "");
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

        public IEnumerable<LiveOrder> Get(Expression<Func<LiveOrder, bool>> filter = null, Func<IQueryable<LiveOrder>, IOrderedQueryable<LiveOrder>> orderBy = null, string includeProperties = "")
        {
            IQueryable<LiveOrder> query = _set;
            if (filter != null) { query = query.Where(filter); }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy == null ? query.ToList() : orderBy(query).ToList();
        }
    }
}
