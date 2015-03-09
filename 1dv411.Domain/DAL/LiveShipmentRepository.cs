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
    public interface ILiveShipmentRepository
    {
        IEnumerable<LiveShipment> Get(
            Expression<Func<LiveShipment, bool>> filter = null,
            Func<IQueryable<LiveShipment>, IOrderedQueryable<LiveShipment>> orderBy = null,
            int? offset = 0,
            int? limit = 1000);
    }
    public class LiveShipmentRepository : ILiveShipmentRepository
    {
        private ILiveShipmentsContext _context;
        private DbSet<LiveShipment> _set;
        public LiveShipmentRepository(ILiveShipmentsContext context)
        {
            _context = context;
            _set = _context.Set<LiveShipment>();
        }

        public IEnumerable<LiveShipment> Get(
            Expression<Func<LiveShipment, bool>> filter = null,
            Func<IQueryable<LiveShipment>, IOrderedQueryable<LiveShipment>> orderBy = null,
            int? offset = 0,
            int? limit = 1000)
        {
            IQueryable<LiveShipment> query = _set;
            if (filter != null) { query = query.Where(filter); }
            if (orderBy != null) { query = orderBy(query); }
            if (offset != null) { query = query.Skip(offset.Value); }
            if (limit != null) { query = query.Take(limit.Value); }
            return query.ToList();
        }
    }
}
