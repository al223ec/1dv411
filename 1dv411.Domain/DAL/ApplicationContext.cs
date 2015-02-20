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
        public DbSet<Template> Templates { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Screen> Screens { get; set; }
        public DbSet<Partial> Partials { get; set;  }

        public DbSet<Diagram> Diagrams { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Text> Texts { get; set; }
        public DbSet<TextContent> TextContents { get; set; }
        public DbSet<PageScreen> PageScreens { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
