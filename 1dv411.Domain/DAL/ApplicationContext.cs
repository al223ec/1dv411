using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public interface IApplicationContext : IDisposable
    {
        DbSet<Diagram> Diagrams { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<PageScreen> PageScreens { get; set; }
        DbSet<Partial> Partials { get; set; }
        DbSet<Screen> Screens { get; set; }
        DbSet<Template> Templates { get; set; }
        DbSet<Text> Texts { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
    }

    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Template> Templates { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Screen> Screens { get; set; }
        public DbSet<Partial> Partials { get; set;  }

        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Text> Texts { get; set; }
        public DbSet<PageScreen> PageScreens { get; set; }
        //TODO:Hur ser databasen ut??

        public ApplicationContext() : base("LocalApplicationDbContext") { }
        /*// Connection string mot skarp databas
        public ApplicationContext() : base("ApplicationDbContext") { }
        */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.HasDefaultSchema("app");
            // One-to-many with Fluent API.
            //modelBuilder.Entity<User>().HasMany<Tweet>(t => t.Tweets).WithRequired(t => t.User).HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
