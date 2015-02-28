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
    public interface ILiveOrdersContext : IDisposable
    {
        DbSet<Order> Orders { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
    public class LiveOrdersContext : DbContext, ILiveOrdersContext
    {
        public DbSet<Order> Orders { get; set; }
        public LiveOrdersContext()
            : base("OrdersDbContext")
        { }
    }
}
