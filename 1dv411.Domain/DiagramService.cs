using _1dv411.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
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

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
