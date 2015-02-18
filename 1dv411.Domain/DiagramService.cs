using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IDiagramService : IDisposable
    {
        IEnumerable<DiagramData> GetDiagramData(int numberOfDays);
        IEnumerable<DiagramData> GetDiagramData(DiagramType? diagramType);
        IEnumerable<DiagramData> GetDiagramDataThisWeek();
        IEnumerable<DiagramData> GetDiagramDataThisMonth();
    }
    public class DiagramService : ServiceBase, IDiagramService
    {
        public IEnumerable<DiagramData> GetDiagramData(int numberOfDays)
        {
            return GetDiagramData(numberOfDays, DateTime.Today); 
        }
        IEnumerable<DiagramData> IDiagramService.GetDiagramDataThisWeek()
        {
            //TODO:Ordna detta 
            return GetDiagramData(7, DateTime.Today); 
        }

        IEnumerable<DiagramData> IDiagramService.GetDiagramDataThisMonth()
        {
            //TODO:Ordna detta 
            return GetDiagramData(30, DateTime.Today);
        }

        private IEnumerable<DiagramData> GetDiagramData(int numberOfDays, DateTime date)
        {
            date = date.Date; 
            //TODO:DENNA METOD 
            //Denna metod returnerar i nuläget inte riktigt korrekt data, måste se till att man hämtar rätt dag från förra året. 
            var diagramData = new List<DiagramData>();
            for (int i = 0; i < numberOfDays; i++)
            {
                var previousYear = date.AddYears(-1); 
                diagramData.Add(
                    new DiagramData
                    {
                        Orders = _unitOfWork.OrderRepository.Get(o => o.Date.Equals(date)).Count(),
                        OrdersLastYear = _unitOfWork.OrderRepository.Get(o => o.Date.Equals(previousYear)).Count(),
                        Date = date,
                    });
                date = date.AddDays(1);
            }
            return diagramData;
        }


        public IEnumerable<DiagramData> GetDiagramData(DiagramType? diagramType)
        {
            switch (diagramType)
            {
                case DiagramType.Week:
                    break;
                case DiagramType.Day:
                    break;
                case DiagramType.Month:
                    break;
                default:
                    break;
            }

            return GetDiagramData(7, DateTime.Now);
        }
    }
}
