namespace _1dv411.Domain.Migrations
{
    using _1dv411.Domain.DbEntities;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1dv411.Domain.DAL.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
           // AutomaticMigrationDataLossAllowed = true; 
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {
           
            var design = new Design();
            design.NumberOfFields = 2;
            context.Designs.Add(design); 
            context.SaveChanges();

            design = context.Designs.FirstOrDefault(d => d.NumberOfFields == 2); 
            Layout layout = new Layout
            {
                Id = 1,
                Name = "TestLayout",
                Design = design,
                DesignId = design.Id,
            };
            context.Layouts.Add(layout);
            context.SaveChanges();

            //var diagrams = new List<Diagram>{
            //    new Diagram
            //    {
            //        Id = 1,
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //        Layout = layout
            //    }
            //};
            //var texts = new List<Text>
            //{
            //    new Text{
            //        Id = 1,
            //        Type = TextType.Header,
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //        Layout = layout
            //    }
            //};
            context.Layouts.Add(layout);
            context.SaveChanges();


            //List<Order> orders = new List<Order>{
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-26"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-27"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-27"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-28"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-28"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-28"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2014-01-28"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2015-01-27"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //    new Order{
            //        OrderGroupId = "StringIdFromDb",
            //        Date = DateTime.Parse("2015-01-27"),
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now,
            //    },
            //};

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
