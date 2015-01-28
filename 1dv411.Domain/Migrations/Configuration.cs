namespace _1dv411.Domain.Migrations
{
    using _1dv411.Domain.DbEntities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1dv411.Domain.DAL.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true; 
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {
            List<Order> orders = new List<Order>{
                new Order{
                    Id = 1,
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-26")
                },
                new Order{
                    Id = 2,
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-27")
                },
                new Order{
                    Id = 3,
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-27")
                },
                new Order{
                    Id = 4,
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28")
                },
                new Order{
                    Id = 5,
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28")
                },
                new Order{
                    Id = 6,
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28")
                },
            };

            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges(); 
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
