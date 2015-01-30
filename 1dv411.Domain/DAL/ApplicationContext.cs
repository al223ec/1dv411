using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Layout> Layouts { get; set; }

        public DbSet<Order> Orders { get; set; }
        //TODO:Hur ser databasen ut??

        public ApplicationContext()
            : base("LocalApplicationDbContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.HasDefaultSchema("app");
            // One-to-many with Fluent API.
            //modelBuilder.Entity<User>().HasMany<Tweet>(t => t.Tweets).WithRequired(t => t.User).HasForeignKey(t => t.UserId);
            //modelBuilder.Entity<Layout>().HasMany<Diagram>(l => l.Diagrams).WithRequired(d => d.Layout).HasForeignKey(t => t.Id);
            //modelBuilder.Entity<Layout>().HasMany<Image>(l => l.Images).WithRequired(d => d.Layout).HasForeignKey(t => t.Id);
            //modelBuilder.Entity<Layout>().HasMany<Text>(l => l.Texts).WithRequired(d => d.Layout).HasForeignKey(t => t.Id);
            //modelBuilder.Entity<Layout>().HasRequired<Design>(l => l.Design);

            base.OnModelCreating(modelBuilder);
        }
    }
}
