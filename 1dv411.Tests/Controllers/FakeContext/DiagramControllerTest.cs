using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1d411.Controllers;
using _1dv411.Domain;
using _1dv411.Domain.DAL;
using _1dv411.Tests.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System.Web.Http.Results;
using _1d411.ViewModel;


namespace _1dv411.Tests.Controllers
{
    [TestClass]
    public class DiagramControllerTest
    {
        private IApplicationContext _context;
        private IServiceFacade _service;
        private List<Order> _orders = new List<Order>();

        public DiagramControllerTest()
        {
            _context = new TestApplicationContext();
            _service = new ServiceFacade(new UnitOfWork(_context));
        }

        [TestMethod]
        public void Get()
        {
            DiagramController controller = new DiagramController(_service);
            var result = controller.GetDataWithDiagramId(1) as OkNegotiatedContentResult<IEnumerable<DiagramData>>;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDataWithDiagramId_WeeklyOrders()
        {
            var diagram = GetDemoDiagram();
            var result = TestNumberOfOrders(diagram); 
        }

        [TestMethod]
        public void GetDataWithDiagramId_MontlyOrders()
        {
            var diagram = GetDemoDiagram(DiagramType.MonthlyOrders);
            var result = TestNumberOfOrders(diagram); 
        }

        [TestMethod]
        public void GetDataWithDiagramId_YearlyOrders()
        {
            var diagram = GetDemoDiagram(DiagramType.YearlyOrders);
            var result = TestNumberOfOrders(diagram); 
        }

        private OkNegotiatedContentResult<IEnumerable<DiagramData>> TestNumberOfOrders(Diagram diagram)
        {
            _context.Diagrams.Add(diagram);
            DiagramController controller = new DiagramController(_service);
            var result = controller.GetDataWithDiagramId(diagram.Id) as OkNegotiatedContentResult<IEnumerable<DiagramData>>;

            Assert.IsNotNull(result);
            // Oklart hur bra detta test egentligen är bör testas mer ingående
            for (int i = 0; i < result.Content.Count(); i++)
            {
                var orders = _orders.Where(o => o.Date == result.Content.ElementAt(i).Date).Count();
                Assert.AreEqual(result.Content.ElementAt(i).Orders, orders);
            }
            return result; 
        }

        private Diagram GetDemoDiagram(DiagramType diagramType = DiagramType.WeeklyOrders, int id = 1)
        {
            return new Diagram { DiagramType = diagramType, Id = id };
        }

        private void SeedData()
        {
            var ordersThisYear = GetTestOrders(DateTime.Today);
            ordersThisYear.ForEach(o => _context.Orders.Add(o));
            var ordersLastYear = GetTestOrders(DateTime.Today.AddYears(-1));
            ordersLastYear.ForEach(o => _context.Orders.Add(o));
        }

        private List<Order> GetTestOrders(DateTime date)
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int numberOfOrders = rnd.Next(1, 13);
                for (int j = 0; j < numberOfOrders; j++)
                {
                    _orders.Add(
                      new Order
                      {
                          Id = date.Millisecond,
                          OrderGroupId = Guid.NewGuid(),
                          Date = date,
                      });
                }
                date = date.AddDays(1);
            }
            return _orders;
        }        
    }
}
