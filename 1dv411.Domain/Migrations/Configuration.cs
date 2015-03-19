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
        private IList<Template> _templates;
        private IList<Page> _pages;
        private IList<Screen> _screens;
        private IList<PageScreen> _pageScreens;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_1dv411.Domain.DAL.ApplicationContext context)
        {
            SeedTemplates(context);
            SeedScreens(context);
            SeedPages(context);
            SeedPagePartials(context);
            SeedPageScreens(context);

            /*För att seeda fakeade ordrar och shipments*/
            var ordersThisYear = GetTestOrders(DateTime.Today);
            ordersThisYear.ForEach(o => context.Orders.AddOrUpdate(o));
            var ordersLastYear = GetTestOrders(DateTime.Today.AddYears(-1));
            ordersLastYear.ForEach(o => context.Orders.AddOrUpdate(o));
            var shipmentsThisYear = GetTestShipments(DateTime.Today);
            shipmentsThisYear.ForEach(s => context.Shipments.AddOrUpdate(s));
            var shipmentsLastYear = GetTestShipments(DateTime.Today.AddYears(-1));
            shipmentsLastYear.ForEach(s => context.Shipments.AddOrUpdate(s));
            context.SaveChanges(); 
        }

        private void SeedTemplates(_1dv411.Domain.DAL.ApplicationContext context)
        {
            _templates = new List<Template>{
                new Template{Name = "default", FileName = "default.html", NumberOfPartials = 1},
                new Template{Name = "Horizontal 1", FileName = "horizontal_1.html", NumberOfPartials = 2},
                new Template{Name = "Horizontal 2", FileName = "horizontal_2.html", NumberOfPartials = 3},
                new Template{Name = "Horizontal 3", FileName = "horizontal_3.html", NumberOfPartials = 2},
                new Template{Name = "Horizontal 4", FileName = "horizontal_4.html", NumberOfPartials = 2},
                new Template{Name = "Horizontal 5", FileName = "horizontal_5.html", NumberOfPartials = 3},
                new Template{Name = "Mixed 1", FileName = "mixed_1.html", NumberOfPartials = 3},
                new Template{Name = "Mixed 2", FileName = "mixed_2.html", NumberOfPartials = 3},
                new Template{Name = "Mixed 3", FileName = "mixed_3.html", NumberOfPartials = 4},
                new Template{Name = "Mixed 4", FileName = "mixed_4.html", NumberOfPartials = 4},
                new Template{Name = "Mixed 5", FileName = "mixed_5.html", NumberOfPartials = 4},
                new Template{Name = "Vertical 1", FileName = "vertical_1.html", NumberOfPartials = 2},
                new Template{Name = "Vertical 2", FileName = "vertical_2.html", NumberOfPartials = 2},
                new Template{Name = "Vertical 3", FileName = "vertical_3.html", NumberOfPartials = 2}
            };
            foreach(Template t in _templates){
                context.Templates.AddOrUpdate(t);
            }
            context.SaveChanges();
        }

        private void SeedPages(_1dv411.Domain.DAL.ApplicationContext context)
        {
            _pages = new List<Page> {
                new Page{Name = "Page 1", Template = _templates[0]},
                new Page{Name = "Page 2", Template = _templates[2]},
                new Page{Name = "Page 3", Template = _templates[6]},
                new Page{Name = "Page 4", Template = _templates[12]}
            };
            foreach (Page p in _pages)
            {
                context.Pages.AddOrUpdate(p);
            }
            context.SaveChanges();
        }

        private void SeedPagePartials(DAL.ApplicationContext context)
        {
            Page p1 = _pages[0];
            p1.Partials = new List<Partial>{
                CreateDiagram (p1, 1, DiagramType.WeeklyOrders)
            };
            Page p2 = _pages[1];
            p2.Partials = new List<Partial>{
                CreateText(p2, 1, "Example Text", "center", "middle", false, true, 5),
                CreateDiagram (p2, 2, DiagramType.WeeklyOrders),
                CreateImage(p2, 3, "http://i.imgur.com/ReWjLO1.jpg"),
            };
            Page p3 = _pages[2];
            p3.Partials = new List<Partial>
            {
                CreateText(p3, 1, "Example Text", "right", "bottom", true, false, 3),
                CreateDiagram (p3, 2, DiagramType.WeeklyOrders),
                CreateImage(p3, 3, "http://i.imgur.com/ReWjLO1.jpg"),
            };
            Page p4 = _pages[3];
            p4.Partials = new List<Partial>
            {
                CreateText(p4, 1, "Example Text", "left", "top", true, true, 6),
                CreateText(p4, 2, "Example Text", "center", "bottom", false, false, 2)
            };
            context.Pages.AddOrUpdate(p1);
            context.Pages.AddOrUpdate(p2);
            context.Pages.AddOrUpdate(p3);
            context.Pages.AddOrUpdate(p4);
            context.SaveChanges();
        }

        private void SeedScreens(_1dv411.Domain.DAL.ApplicationContext context)
        {
            _screens = new List<Screen> {
                new Screen{Name = "Screen 1", Timer = 5000},
                new Screen{Name = "Screen 2", Timer = 6000},
                new Screen{Name = "Screen 3", Timer = 7000}
            };
            foreach (Screen s in _screens)
            {
                context.Screens.AddOrUpdate(s);
            }
            context.SaveChanges();
        }

        private void SeedPageScreens(DAL.ApplicationContext context)
        {
           _pageScreens = new List<PageScreen>{
                new PageScreen { Screen = _screens[0], Page = _pages[0] },
                new PageScreen { Screen = _screens[0], Page = _pages[1] },
                new PageScreen { Screen = _screens[1], Page = _pages[3] },
                new PageScreen { Screen = _screens[1], Page = _pages[2] },
                new PageScreen { Screen = _screens[2], Page = _pages[1] },
                new PageScreen { Screen = _screens[2], Page = _pages[2] },
                new PageScreen { Screen = _screens[2], Page = _pages[3] }
            };
            foreach (PageScreen ps in _pageScreens)
            {
                context.PageScreens.AddOrUpdate(ps);
            }
            context.SaveChanges();
        }

        private Text CreateText(Page page, int position, string content, string align = "center", string valign = "middle", bool bold = false, bool italic = false, int fontSize = 4)
        {
            return new Text
            {
                Page = page,
                Position = position,
                Content = content,
                Align = align,
                Valign = valign,
                Bold = bold,
                Italic = italic,
                FontSize = fontSize
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
            var url = string.Format("{0}", filename == null ? "" : filename);
            return new Image
            {
                Page = page,
                Position = position,
                Url = url
            };
        }


        /* Seed statistics methods */
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
