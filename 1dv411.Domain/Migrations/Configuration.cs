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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {
            /*
                        * TODO: Fixa mer och bättre testdata 
                        * kommentera bort detta som default, kör endast en gång 
            
            */
            var hero = SeedHero(context);
            var def = SeedDefault(context);
            var hor = SeedHorizontal(context);

            Screen screen = new Screen
            {
                 Name = "Lager"
            };
            PageScreen pageScreenHero = new PageScreen
            {
                Page = hero,
                Screen = screen,
            };
            PageScreen pageScreenDef = new PageScreen
            {
                Page = def,
                Screen = screen,
            };
            Screen fika = new Screen
            {
                Name = "Fika"
            };
            PageScreen pageScreenHor = new PageScreen
            {
                Page = hor,
                Screen = fika,
            };

            context.PageScreens.Add(pageScreenHor);
            context.PageScreens.Add(pageScreenHero);
            context.PageScreens.Add(pageScreenDef);
            context.SaveChanges();

            /**** För att seeda ordrar och shipments
            var ordersThisYear = GetTestOrders(DateTime.Today);
            ordersThisYear.ForEach(o => context.Orders.AddOrUpdate(o));
            var ordersLastYear = GetTestOrders(DateTime.Today.AddYears(-1));
            ordersLastYear.ForEach(o => context.Orders.AddOrUpdate(o));

            var shipmentsThisYear = GetTestShipments(DateTime.Today);
            shipmentsThisYear.ForEach(s => context.Shipments.AddOrUpdate(s));
            var shipmentsLastYear = GetTestShipments(DateTime.Today.AddYears(-1));
            shipmentsLastYear.ForEach(s => context.Shipments.AddOrUpdate(s));
            
            context.SaveChanges(); 
            /**/
        }

        private Page CreatePage(string name, string templateFileName, int numberOfPartials)
        {
            Template template = new Template
            {
                Name = string.Format("Template name for {0}", templateFileName),
                FileName = templateFileName,
                NumberOfPartials = numberOfPartials
            }; 
            Page page = new Page
            {
                Name = name,
                Template = template,
            };
            return page;
        }

        private Text CreateText(Page page, int position, string content)
        {
            return new Text
            {
                Page = page,
                Position = position,
                Content = content,
            };
        }

        private Diagram CreateDiagram(Page page, int position, DiagramType type)
        {
            return new Diagram
            {
                Page = page,
                Position = position,
                DiagramType = type
            };
        }

        private Image CreateImage(Page page, int position, string filename = null)
        {
            var url = string.Format("/Views/App/Partials/Images/{0}", filename == null ? "" : filename); 
            return new Image
            {
                Page = page,
                Position = position,
                Url = url
            };
        }
        private Page SeedHero(DAL.ApplicationContext context)
        {
            Page hero = CreatePage("Hero", "hero.html", 3);

            var partials = new List<Partial>
            {
                CreateText(hero, 1, "Hero heading"),
                CreateDiagram (hero, 2, DiagramType.WeeklyOrders),
                CreateImage(hero, 3, "dodge.jpg"),
            };

            hero.Partials = partials;
            return AddOrUpdatePage(context, hero);

        }
        private Page SeedDefault(DAL.ApplicationContext context)
        {
            Page defaultPage = CreatePage("Default page", "default_template.html", 2);
            var partials = new List<Partial>
            {
                CreateText(defaultPage, 1, "Default page text"),
                CreateDiagram (defaultPage, 2, DiagramType.WeeklyOrders),
            };

            defaultPage.Partials = partials;
            return AddOrUpdatePage(context, defaultPage);
        }
        private void SeedVertical(DAL.ApplicationContext context)
        {
            throw new NotImplementedException();
        }
        private Page SeedHorizontal(DAL.ApplicationContext context)
        {
            Page horizontal = CreatePage("Horizontal page", "horizontal.html", 3);

            var partials = new List<Partial>
            {
                CreateDiagram (horizontal, 1, DiagramType.WeeklyOrders),
                CreateDiagram (horizontal, 2, DiagramType.MonthlyOrders),
                CreateDiagram (horizontal, 3, DiagramType.YearlyOrders),
            };

            horizontal.Partials = partials;
            return AddOrUpdatePage(context, horizontal);
        }
        private Page AddOrUpdatePage(DAL.ApplicationContext context, Page page)
        {
            context.Pages.AddOrUpdate(l => l.Name, page);
            context.SaveChanges();
            return page;
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
                          OrderGroupId = Guid.NewGuid(),
                          Date = date,
                      });
                }
                date = date.AddDays(1);
            }
            return orders;
        }
        private List<Shipment> GetTestShipments(DateTime date)
        {
            Random rnd = new Random();
            List<Shipment> shipments = new List<Shipment>();
            for (int i = 0; i < 150; i++)
            {
                int numberOfOrders = rnd.Next(1, 13);
                for (int j = 0; j < numberOfOrders; j++)
                {
                    shipments.Add(
                      new Shipment
                      {
                          No_ = "some-id",
                          PostingDate = date,
                      });
                }
                date = date.AddDays(1);
            }
            return shipments;
        }
    }
}
