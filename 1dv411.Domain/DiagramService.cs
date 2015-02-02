using _1dv411.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public class DiagramService : IDiagramService
    {
        private IUnitOfWork _unitOfWork; 

        public DiagramService()
            : this(new UnitOfWork())
        { }
        public DiagramService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public IEnumerable<DiagramData> GetDiagramData(string query)
        {
            var date = DateTime.Parse("2014-01-28"); 

            return new List<DiagramData>{
                new DiagramData{
                    Orders = _unitOfWork.OrderRepository.Get(o => o.Date.Equals(date)).Count(),
                    OrdersLastYear = 125,
                    Date = date,
                },
            };
        }
        public IEnumerable<DiagramData> GetDiagramData(int numberOfDays)
        {
            var date = DateTime.Parse("2014-01-28"); 
            var diagramData = new List<DiagramData>(); 
            
            for (int i = 0; i < numberOfDays; i++)
			{   
			    diagramData.Add(
                    new DiagramData{
                        Orders = _unitOfWork.OrderRepository.Get(o => o.Date.Equals(date)).Count(),
                        OrdersLastYear = 125,
                        Date = date,
                });
                date.AddDays(1); 
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
