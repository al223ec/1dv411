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
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {   /*
             * TODO: Fixa mer och bättre testdata */

            SeedHero(context);
            SeedDefault(context);
            //SeedVertical(context);
            SeedHorizontal(context); 
            
            /****
            Screen screen = new Screen
            {
                  Name = "fika"
            };
            LayoutScreen layoutScreen = new LayoutScreen
            {
                Layout = layout,
                Screen = screen,
            };
            context.LayoutScreens.Add(layoutScreen);

            /**** För att seeda ordrar    
                var ordersThisYear = GetTestOrders(DateTime.Today);
                ordersThisYear.ForEach(o => context.Orders.AddOrUpdate(o));
                var ordersLastYear = GetTestOrders(DateTime.Today.AddYears(-1));
                ordersLastYear.ForEach(o => context.Orders.AddOrUpdate(o));
                context.SaveChanges(); 
             * */

        }
        private Layout CreateLayout(string name, string template)
        {
            Layout layout = new Layout
            {
                Name = name,
                TemplateUrl = template,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            return layout; 
        }

        private Text CreateText(Layout layout, int position, string value)
        {
            return new Text
            {
                Layout = layout,
                Position = position,
                Heading = value,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            }; 
        }

        private Diagram CreateDiagram(Layout layout, int position, int info)
        {
            return new Diagram
            {
                Layout = layout,
                Position = position,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                DiagramInfo = info,
            };
        }

        private Image CreateImage()
        {
            throw new NotImplementedException(); 
        }
        private void SeedHero(DAL.ApplicationContext context)
        {
            Layout hero = CreateLayout("Hero", "hero"); 

            var partials = new List<Partial>
            {
                CreateText(hero, 1, "hero Fet texta sd as  sdasd lorem"),
                CreateDiagram (hero, 2, 666),
                CreateText(hero, 3, "En till text för hero Fet texta sd as  sdasd lorem"),
            };

            hero.Partials = partials;
            context.Layouts.Add(hero);
            context.SaveChanges();
            
        }
        private void SeedDefault(DAL.ApplicationContext context)
        {
            Layout defaultLayout = CreateLayout("Default layout", "default_template");
            var partials = new List<Partial>
            {
                CreateText(defaultLayout, 1, "Default layout text"),
                CreateDiagram (defaultLayout, 2, 222),
            };

            defaultLayout.Partials = partials;
            context.Layouts.Add(defaultLayout);
            context.SaveChanges();
        }
        private void SeedVertical(DAL.ApplicationContext context)
        {
            throw new NotImplementedException();
        }
        private void SeedHorizontal(DAL.ApplicationContext context)
        {
            Layout horizontal = CreateLayout("Horizontal layout", "horizontal");

            var partials = new List<Partial>
            {
                CreateDiagram (horizontal, 1, 111),
                CreateDiagram (horizontal, 2, 222),
                CreateDiagram (horizontal, 3, 333),
            };

            horizontal.Partials = partials;
            context.Layouts.Add(horizontal);
            context.SaveChanges();
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
