using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DAL
{
    class ApplicationContext : DbContext
    {
        public DbSet<DiagramData> DiagramData { get; set; }

        public DbSet<Screen> Screens { get; set; }
        //TODO:Hur ser databasen ut

        public ApplicationContext()
            :base("ApplicationConnectionString")
        { }
    }
}
