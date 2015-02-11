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
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {   /*
             * TODO: Fixa mer och bättre testdata
            Layout layout = new Layout
            {
                Name = "TestLayout2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var partials = new List<Partial>
            {
                //new Partial{
                //    Position = 1,
                //    LayoutId = 1,
                //    CreatedAt = DateTime.Now,
                //    ModifiedAt = DateTime.Now,
                //},
                new Text{
                    LayoutId = 1,
                    Position = 1,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Value = "Some text"
                },
                new Diagram
                {
                    LayoutId = 1,
                    Position = 2,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    DiagramInfo = 123, 
                },
            };

            //layout.Partials = partials;
            //context.Layouts.Add(layout);
            partials.ForEach(p => context.Partials.Add(p)); 
            context.SaveChanges();*/
            /*
            var diagrams = new List<Diagram>{
                  new Diagram
                  {
                      CreatedAt = DateTime.Now,
                      ModifiedAt = DateTime.Now,
                      DiagramInfo = 123, 
                  }
              };
            diagrams.ForEach(d => partials.Add(d));
            var texts = new List<Text>{
                  new Text
                  {
                      Type = TextType.Header,
                      CreatedAt = DateTime.Now,
                      ModifiedAt = DateTime.Now,
                      Value = "Some text"
                  },
              };
            texts.ForEach(d => partials.Add(d));

            context.Layouts.Add(layout);
            context.SaveChanges();

            partials.ForEach(p => context.Partials.Add(p)); 
            context.SaveChanges(); 

            Screen screen = new Screen
              {
                  Name = "lager"
              };
            LayoutScreen layoutScreen = new LayoutScreen
            {
                Layout = layout,
                Screen = screen,
            };
            context.LayoutScreens.Add(layoutScreen);

            /**** För att seeda orders 
                var ordersThisYear = GetTestOrders(DateTime.Today);
                ordersThisYear.ForEach(o => context.Orders.AddOrUpdate(o));
                var ordersLastYear = GetTestOrders(DateTime.Today.AddYears(-1));
                ordersLastYear.ForEach(o => context.Orders.AddOrUpdate(o));
                context.SaveChanges(); 
           */
        }
        private List<Order> GetTestOrders(DateTime date)
        {
            Random rnd = new Random();
            List<Order> orders = new List<Order>();
            for (int i = 0; i < 150; i++)
            {
                int numberOfOrders = rnd.Next(1, 13);
                for (int j = 0; j < numberOfOrders; j++)
                {
                    orders.Add(
                      new Order
                      {
                          OrderGroupId = "StringIdFromDb",
                          Date = date,
                          CreatedAt = date,
                          ModifiedAt = date,
                      });
                }
                date = date.AddDays(1);
            }
            return orders;
        }
    }
}
