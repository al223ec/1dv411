using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Tests.Domain.DAL
{
    public class TestApplicationContext : IApplicationContext
    {
        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageScreen> PageScreens { get; set; }
        public DbSet<Partial> Partials { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Text> Texts { get; set; }

        public TestApplicationContext()
        {
            this.Screens = new TestDbSet<Screen>();
            this.Pages = new TestDbSet<Page>();
            this.PageScreens = new TestDbSet<PageScreen>();
            this.Diagrams = new TestDbSet<Diagram>();
            this.Images = new TestDbSet<Image>();
            this.Orders = new TestDbSet<Order>();
            this.Partials = new TestDbSet<Partial>();
            this.Templates = new TestDbSet<Template>();
            this.Texts = new TestDbSet<Text>(); 
        }

        
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            foreach (PropertyInfo property in typeof(TestApplicationContext).GetProperties())
            {
                if (property.PropertyType == typeof(DbSet<TEntity>))
                {
                    return property.GetValue(this, null) as DbSet<TEntity>;
                }
            }
            throw new Exception("Type collection not found");
        }

        public DbSet Set(Type entityType)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            _modified = false; 
            return 0;
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        { }


        private bool _modified = false; 
        public void SetModified(object entity)
        {
            _modified = true; 
        }
    }
}
