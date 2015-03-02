using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IDiagramService
    {
        IEnumerable<DiagramData> GetDiagramData(DiagramType? diagramType);
        IEnumerable<DiagramData> GetDataWithDiagramId(int id);

        int SeedLiveOrders(DateTime? limitSince = null);
    }
    public class DiagramService : IDiagramService
    {
        private IUnitOfWork _unitOfWork;
        private ILiveOrderService _liveOrderService;

        #region Constructor
        public DiagramService(IUnitOfWork unitOfWork, ILiveOrderService liveOrderService)
        {
            _unitOfWork = unitOfWork;
            _liveOrderService = liveOrderService;
        }
        #endregion

        private IEnumerable<DiagramData> GetDiagramData(int numberOfDays, DateTime date)
        {
            date = date.Date; //Tar bort time delen av datumet, eller nollställer den
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

        //TODO: Fixa
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

        public IEnumerable<DiagramData> GetDataWithDiagramId(int id)
        {
            var diagram = _unitOfWork.DiagramRepository.Get(d => d.Id == id).FirstOrDefault(); 
            return diagram != null ? GetDiagramData(diagram.DiagramType)  : null; 
        }


        public int SeedLiveOrders(DateTime? limitSince = null)
        {
            
            IEnumerable<LiveOrder> liveorders = _liveOrderService.GetLiveOrdersSince(limitSince.Value);
            
            int addedCount = 0;
            //If DB is empty just run without checking for doubles
            if (!_unitOfWork.OrderRepository.Get().Any())
            {
                foreach (var lo in liveorders)
                {
                    _unitOfWork.OrderRepository.AddOrUpdate(new Order { OrderGroupId = lo.OrderGroupId, Date = lo.Created });
                    addedCount++;
                }
            }
            else //Check every order before saving to prevent doubles
            {
                foreach (var lo in liveorders)
                {
                    if (_unitOfWork.OrderRepository.Get(o => o.OrderGroupId == lo.OrderGroupId).Any())
                    {
                        _unitOfWork.OrderRepository.AddOrUpdate(new Order { OrderGroupId = lo.OrderGroupId, Date = lo.Created });
                        addedCount++;
                    }
                }
            }
            _unitOfWork.Save();
            return addedCount;
        }
    }
}
