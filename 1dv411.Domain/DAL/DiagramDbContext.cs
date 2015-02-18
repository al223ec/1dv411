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
    //Får se om detta implemnteras
    //class DiagramDbContext : DbContext
    //{
    //    public DbSet<Order> Orders { get; set; }
    //    public DiagramDbContext()
    //        : base("LocalDiagramDbContext")
    //    { }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}
    //http://stackoverflow.com/questions/13469881/how-do-i-enable-ef-migrations-for-multiple-contexts-to-separate-databases
}
