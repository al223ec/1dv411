using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public interface ILiveShipmentsContext : IDisposable
    {
        DbSet<LiveShipment> LiveShipments { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
    public class LiveShipmentsContext : DbContext, ILiveShipmentsContext
    {
        public DbSet<LiveShipment> LiveShipments { get; set; }
        public LiveShipmentsContext()
            : base("ShipmentsDbContext")
        { }
    }
}
