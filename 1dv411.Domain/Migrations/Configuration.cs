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
                        * TODO: Fixa mer och b�ttre testdata 
                        * kommentera bort detta som default, k�r endast en g�ng 
            
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

            /**** F�r att seeda ordrar     
                var ordersThisYear = GetTestOrders(DateTime.Today);
                ordersThisYear.ForEach(o => context.Orders.AddOrUpdate(o));
                var ordersLastYear = GetTestOrders(DateTime.Today.AddYears(-1));
                ordersLastYear.ForEach(o => context.Orders.AddOrUpdate(o));
                context.SaveChanges();  */
            /**/
        }

        private Page CreatePage(string name, string templateFileName)
        {
            Template template = new Template
            {
                FileName = templateFileName,
            };
            Page page = new Page
            {
                Name = name,
                Template = template,

            };
            return page;
        }

        private Text CreateText(Page page, int position, string heading, string[] paragraphs, string footer = null)
        {
            var textContents = new List<_1dv411.Domain.DbEntities.TextContent>{
                    new _1dv411.Domain.DbEntities.TextContent {
                        TextType = TextType.Heading,
                        Content = heading,
                    },
                    new _1dv411.Domain.DbEntities.TextContent {
                        TextType = TextType.Footer,
                        Content = footer,
                    }
                };

            for (int i = 0; i < paragraphs.Count(); i++)
            {
                textContents.Add(new _1dv411.Domain.DbEntities.TextContent
                {
                    TextType = TextType.Paragraph,
                    Content = paragraphs[i],
                });
            }

            return new Text
            {
                Page = page,
                Position = position,
                TextContents = textContents,
            };
        }

        private Diagram CreateDiagram(Page page, int position, int info)
        {
            return new Diagram
            {
                Page = page,
                Position = position,
                DiagramInfo = info,
                DiagramType = DiagramType.Week
            };
        }

        private Image CreateImage()
        {
            throw new NotImplementedException();
        }
        private Page SeedHero(DAL.ApplicationContext context)
        {
            Page hero = CreatePage("Hero", "hero.html");

            var partials = new List<Partial>
            {
                CreateText(hero, 1, "Hero heading", new string[] {
                    "A defense officer, Nameless, was summoned by the King of Qin regarding his success of terminating three warriors.",
                    "In ancient China, before the reign of the first emperor, warring factions throughout the Six Kingdoms plot to assassinate the most powerful ruler, Qin. When a minor official defeats Qin's three principal enemies, he is summoned to the palace to tell Qin the story of his surprising victory",
                },
                "Footer ska max finnas en g�ng per text"),
                CreateDiagram (hero, 2, 666),
                CreateText(hero, 3, "Flying Daggers", new string[] {
                    "A romantic police captain breaks a beautiful member of a rebel group out of prison to help her rejoin her fellows, but things are not what they seem.",
                    "During the reign of the Tang dynasty in China, a secret organization called 'The House of the Flying Daggers' rises and opposes the government. A police officer called Leo sends officer Jin to investigate a young dancer named Mei, claiming that she has ties to the 'Flying Daggers'. Leo arrests Mei, only to have Jin breaking her free in a plot to gain her trust and lead the police to the new leader of the secret organization. But things are far more complicated than they seem...",
                    "To prepare for her role, Ziyi Zhang lived with a blind girl for two months. The blind girl became blind at the age of 12 because of a brain tumor.",
                    "Towards the end of the 'Echo Game', Leo throws the entire bowl of beans into the drums. They fall the floor, but when Leo moves to Mei, they have all disappeared."
                },
                "Footer ska max finnas en g�ng per text"
                ),
            };

            hero.Partials = partials;
            return AddOrUpdatePage(context, hero);

        }
        private Page SeedDefault(DAL.ApplicationContext context)
        {
            Page defaultPage = CreatePage("Default page", "default_template.html");
            var partials = new List<Partial>
            {
                CreateText(defaultPage, 1, "Default page text", new string[] {
                    "Usually what you choose will depend on which methods you need access to. In general - IEnumerable<> (MSDN: http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx) for a list of objects that only needs to be iterated through, ICollection<> (MSDN: http://msdn.microsoft.com/en-us/library/92t2ye13.aspx) for a list of objects that needs to be iterated through and modified, List<> for a list of objects that needs to be iterated through, modified, sorted, etc (See here for a full list: http://msdn.microsoft.com/en-us/library/6sh2ey19.aspx)."
                }),
                CreateDiagram (defaultPage, 2, 222),
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
            Page horizontal = CreatePage("Horizontal page", "horizontal.html");

            var partials = new List<Partial>
            {
                CreateDiagram (horizontal, 1, 111),
                CreateDiagram (horizontal, 2, 222),
                CreateDiagram (horizontal, 3, 333),
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
    }
}
