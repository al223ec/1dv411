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
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {

            var design = new Design();
            design.NumberOfFields = 2;

            Layout layout = new Layout
            {
                Name = "TestLayout",
                Design = design,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            var diagrams = new List<Diagram>{
                new Diagram
                {
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Layout = layout
                }
            };
            layout.Diagrams = diagrams;

            var texts = new List<Text>
            {
                new Text{
                    Type = TextType.Header,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Layout = layout
                }
            };
            layout.Texts = texts;

            context.Layouts.AddOrUpdate(layout);
            context.SaveChanges(); 

            List<Order> orders = new List<Order>{
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-26"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-27"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-27"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2014-01-28"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2015-01-27"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new Order{
                    OrderGroupId = "StringIdFromDb",
                    Date = DateTime.Parse("2015-01-27"),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
            };
            orders.ForEach(o => context.Orders.AddOrUpdate(o)); 
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
