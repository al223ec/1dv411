using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IDiagramService
    {
        IEnumerable<DiagramData> GetDataWithDiagramId(int id);
        IEnumerable<DiagramData> GetWeekDiagramData(Diagram diagram);
        IEnumerable<DiagramData> GetMonthDiagramData(Diagram diagram);
        IEnumerable<DiagramData> GetQuarterDiagramData(Diagram diagram);
        IEnumerable<DiagramData> GetYearDiagramData(Diagram diagram);

        object SeedLiveOrders(int year, int month);
        object SeedLiveShipments(int year, int month);
        object GetApplicationStats();
    }
    public class DiagramService : IDiagramService
    {
        private IUnitOfWork _unitOfWork;
        private ILiveOrderService _liveOrderService;
        private ILiveShipmentService _liveShipmentService;

        #region Constructor
        public DiagramService(IUnitOfWork unitOfWork, ILiveOrderService liveOrderService, ILiveShipmentService liveShipmentService)
        {
            _unitOfWork = unitOfWork;
            _liveOrderService = liveOrderService;
            _liveShipmentService = liveShipmentService;
        }
        #endregion

        /*
        private IEnumerable<DiagramData> GetOrderDiagramData(int numberOfDays, DateTime date, DateTime lastYear)
        {

            //LINQ löser inte datum-formatering, får hämta all data inom ett intervall och manuellt sortera
            var diagramData = new List<DiagramData>();
            for (int i = 0; i < numberOfDays; i++)
            {
                diagramData.Add(new DiagramData
                {
                    //Kan inte använda datum alls med TEntity i linq. Måste jämföra år, månad och dag
                    Orders = _unitOfWork.OrderRepository.Count(o => o.Date.Year == date.Year && o.Date.Month == date.Month && o.Date.Day == date.Day),
                    OrdersLastYear = _unitOfWork.OrderRepository.Count(o => o.Date.Year == lastYear.Year && o.Date.Month == lastYear.Month && o.Date.Day == lastYear.Day),
                    Date = date
                });
                date = date.AddDays(1);
                lastYear = lastYear.AddDays(1);
            }
            return diagramData;
        }

        public IEnumerable<DiagramData> GetDiagramData(DiagramType? diagramType)
        {
            //Uppdaterar Order-data om det behövs 
            //UpdateOrderData();
            

            DateTime startDate = DateTime.Now;
            DateTime lastYear = DateTime.Now.AddYears(-1);
            int numberOfDays = 0;
            switch (diagramType)
            {
                case DiagramType.WeeklyOrders:
                    numberOfDays = 7;
                    startDate = TransformDateToMondayOfSameWeek(startDate);
                    lastYear = TransformDateToMondayOfSameWeekLastYear(startDate);
                    break;
                case DiagramType.MonthlyOrders:
                    numberOfDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    startDate = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                    lastYear = startDate.AddYears(-1);
                    break;
                case DiagramType.QuarterlyOrders:
                    numberOfDays = CalculateDaysOfQuarter(startDate);
                    startDate = GetStartDateOfQuarter(startDate);
                    lastYear = startDate.AddYears(-1);
                    break;
                case DiagramType.YearlyOrders:
                    numberOfDays = new DateTime(DateTime.Now.Year, 12, 31).DayOfYear;
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    lastYear = startDate.AddYears(-1);
                    break;
            }

            return GetOrderDiagramData(numberOfDays, startDate, lastYear);
        }

        public IEnumerable<DiagramData> GetDataWithDiagramId(int id)
        {
            var diagram = _unitOfWork.DiagramRepository.Get(d => d.Id == id).FirstOrDefault(); 
            return diagram != null ? GetDiagramData(diagram.DiagramType) : null; 
        }
*/

        public IEnumerable<DiagramData> GetDataWithDiagramId(int id)
        {

            //UpdateOrderData();
            //UpdateShipmentData();

            var diagram = _unitOfWork.DiagramRepository.Get(d => d.Id == id).FirstOrDefault();
            if (diagram.DiagramType == DiagramType.WeeklyOrders || diagram.DiagramType == DiagramType.WeeklyShipments)
            {
                return GetWeekDiagramData(diagram);
            }
            if (diagram.DiagramType == DiagramType.MonthlyOrders || diagram.DiagramType == DiagramType.MontlyShipments)
            {
                return GetMonthDiagramData(diagram);
            }
            if (diagram.DiagramType == DiagramType.QuarterlyOrders || diagram.DiagramType == DiagramType.QuarterlyShipments)
            {
                return GetQuarterDiagramData(diagram);
            }
            if (diagram.DiagramType == DiagramType.YearlyOrders || diagram.DiagramType == DiagramType.YearlyShipments)
            {
                return GetYearDiagramData(diagram);
            }
            return null;
        }

        public IEnumerable<DiagramData> GetWeekDiagramData(Diagram diagram)
        {
            var thisYear = TransformDateToMondayOfSameWeek(DateTime.Now);
            var lastYear = TransformDateToMondayOfSameWeekLastYear(thisYear);
            var diagramData = new List<DiagramData>();
            for (int i = 0; i < 7; i++)
            {
                if (diagram.DiagramType == DiagramType.WeeklyOrders)
                {
                    diagramData.Add(new DiagramData{
                        Orders = _unitOfWork.OrderRepository.Count(o => o.Date.Year == thisYear.Year && o.Date.Month == thisYear.Month && o.Date.Day == thisYear.Day),
                        OrdersLastYear = _unitOfWork.OrderRepository.Count(o => o.Date.Year == lastYear.Year && o.Date.Month == lastYear.Month && o.Date.Day == lastYear.Day),
                        Date = thisYear.DayOfWeek.ToString()
                    });
                }
                else
                {
                    diagramData.Add(new DiagramData{
                        Orders = _unitOfWork.ShipmentRepository.Count(o => o.PostingDate.Year == thisYear.Year && o.PostingDate.Month == thisYear.Month && o.PostingDate.Day == thisYear.Day),
                        OrdersLastYear = _unitOfWork.ShipmentRepository.Count(o => o.PostingDate.Year == lastYear.Year && o.PostingDate.Month == lastYear.Month && o.PostingDate.Day == lastYear.Day),
                        Date = thisYear.DayOfWeek.ToString()
                    });
                }
                thisYear = thisYear.AddDays(1);
                lastYear = lastYear.AddDays(1);
            }
            return diagramData;
        }

        public IEnumerable<DiagramData> GetMonthDiagramData(Diagram diagram)
        {
            var numberOfDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var thisYear = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            var lastYear = thisYear.AddYears(-1);
            var diagramData = new List<DiagramData>();
            for (int i = 0; i < numberOfDays; i++)
            {
                if (diagram.DiagramType == DiagramType.MonthlyOrders)
                {
                    diagramData.Add(new DiagramData{
                        Orders = _unitOfWork.OrderRepository.Count(o => o.Date.Year == thisYear.Year && o.Date.Month == thisYear.Month && o.Date.Day == thisYear.Day),
                        OrdersLastYear = _unitOfWork.OrderRepository.Count(o => o.Date.Year == lastYear.Year && o.Date.Month == lastYear.Month && o.Date.Day == lastYear.Day),
                        Date = thisYear.Day.ToString()
                    });
                }
                else
                {
                    diagramData.Add(new DiagramData{
                        Orders = _unitOfWork.ShipmentRepository.Count(o => o.PostingDate.Year == thisYear.Year && o.PostingDate.Month == thisYear.Month && o.PostingDate.Day == thisYear.Day),
                        OrdersLastYear = _unitOfWork.ShipmentRepository.Count(o => o.PostingDate.Year == lastYear.Year && o.PostingDate.Month == lastYear.Month && o.PostingDate.Day == lastYear.Day),
                        Date = thisYear.Day.ToString()
                    });
                }
                thisYear = thisYear.AddDays(1);
                lastYear = lastYear.AddDays(1);
            }
            return diagramData;
        }

        public IEnumerable<DiagramData> GetQuarterDiagramData(Diagram diagram)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiagramData> GetYearDiagramData(Diagram diagram)
        {
            var thisYear = new DateTime(DateTime.Now.Year, 1, 1);
            var lastYear = thisYear.AddYears(-1);
            var diagramData = new List<DiagramData>();

            for (int i = 1; i <= 12; i++)
            {
                if (diagram.DiagramType == DiagramType.YearlyOrders)
                {
                    diagramData.Add(new DiagramData{
                        Orders = _unitOfWork.OrderRepository.Count(o => o.Date.Year == thisYear.Year && o.Date.Month == thisYear.Month),
                        OrdersLastYear = _unitOfWork.OrderRepository.Count(o => o.Date.Year == lastYear.Year && o.Date.Month == lastYear.Month),
                        Date = thisYear.Month.ToString()
                    });
                }
                else
                {
                    diagramData.Add(new DiagramData{
                        Orders = _unitOfWork.ShipmentRepository.Count(o => o.PostingDate.Year == thisYear.Year && o.PostingDate.Month == thisYear.Month),
                        OrdersLastYear = _unitOfWork.ShipmentRepository.Count(o => o.PostingDate.Year == lastYear.Year && o.PostingDate.Month == lastYear.Month),
                        Date = thisYear.Month.ToString()
                    });
                }
                thisYear = thisYear.AddMonths(1);
                lastYear = lastYear.AddMonths(1);
            }

            return diagramData;
        }


        /*
         * NYA DIAGRAMDATAMETODER
         * 
        */
        private void UpdateOrderData()
        {
            Order lastOrder = _unitOfWork.OrderRepository.GetOne(null, q => q.OrderByDescending(o => o.Date));
            TimeSpan diffCheck = DateTime.Now - lastOrder.CreatedAt;
            if (diffCheck.Minutes > 5)
            {
                IEnumerable<LiveOrder> liveorders = _liveOrderService.GetLiveOrdersSince(lastOrder.Date);
                foreach (var lo in liveorders)
                {
                    _unitOfWork.OrderRepository.AddOrUpdate(new Order { OrderGroupId = lo.OrderGroupId, Date = lo.Created });
                }
                _unitOfWork.Save();
            }
        }
        private void UpdateShipmentData()
        {
            Shipment lastShipment = _unitOfWork.ShipmentRepository.GetOne(null, q => q.OrderByDescending(o => o.PostingDate));
            TimeSpan diffCheck = DateTime.Now - lastShipment.CreatedAt;
            if (diffCheck.Minutes > 5)
            {
                IEnumerable<LiveShipment> liveshipments = _liveShipmentService.GetLiveShipmentsSince(lastShipment.PostingDate);
                foreach (var ls in liveshipments)
                {
                    _unitOfWork.ShipmentRepository.AddOrUpdate(new Shipment { No_ = ls.No_, PostingDate = ls.PostingDate});
                }
                _unitOfWork.Save();
            }
        }
        private DateTime TransformDateToMondayOfSameWeek(DateTime date)
        {
            var dayOfWeek = (int)date.DayOfWeek;
            var diffToMonday = (dayOfWeek == 0) ? 1 - 7 : 1 - dayOfWeek;

            return date.AddDays(diffToMonday);
        }
        private DateTime TransformDateToMondayOfSameWeekLastYear(DateTime thisYearStartDate)
        {
            DateTime lastYearStartDate = thisYearStartDate.AddYears(-1);

            //Get week numbers for current and last year
            var currCulture = CultureInfo.CurrentCulture;
            var weekThisYear = currCulture.Calendar.GetWeekOfYear(
                thisYearStartDate,
                currCulture.DateTimeFormat.CalendarWeekRule,
                currCulture.DateTimeFormat.FirstDayOfWeek);
            var weekLastYear = currCulture.Calendar.GetWeekOfYear(
                lastYearStartDate,
                currCulture.DateTimeFormat.CalendarWeekRule,
                currCulture.DateTimeFormat.FirstDayOfWeek);

            lastYearStartDate = (weekThisYear != weekLastYear) ? lastYearStartDate.AddDays(7 * (weekThisYear - weekLastYear)) : lastYearStartDate;
            lastYearStartDate = TransformDateToMondayOfSameWeek(lastYearStartDate);
            return lastYearStartDate;
        }

        private DateTime GetStartDateOfQuarter(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            if (month >= 4 && month <= 6)
            {
                return new DateTime(year, 4, 1);
            }
            else if (month >= 7 && month <= 9)
            {
                return new DateTime(year, 7, 1);
            }
            else if (month >= 10 && month <= 12)
            {
                return new DateTime(year, 10, 1);
            }
            else
            {
                return new DateTime(year, 1, 1);
            }
        }

        private int CalculateDaysOfQuarter(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            if (month >= 4 && month <= 6)
            {
                return DateTime.DaysInMonth(year, 4) + DateTime.DaysInMonth(year, 5) + DateTime.DaysInMonth(year, 6);
            }
            else if (month >= 7 && month <= 9)
            {
                return DateTime.DaysInMonth(year, 7) + DateTime.DaysInMonth(year, 8) + DateTime.DaysInMonth(year, 9);
            }
            else if (month >= 10 && month <= 12)
            {
                return DateTime.DaysInMonth(year, 10) + DateTime.DaysInMonth(year, 11) + DateTime.DaysInMonth(year, 12);
            }
            else
            {
                return DateTime.DaysInMonth(year, 1) + DateTime.DaysInMonth(year, 2) + DateTime.DaysInMonth(year, 3);
            }
        }



        /*
         *  SEED FRÅN SKARP DATABAS MED ORDRAR
         *  flytta?
        */
        public object SeedLiveOrders(int year, int month)
        {

            IEnumerable<LiveOrder> liveorders = _liveOrderService.GetLiveOrdersFor(year, month);

            int addedCount = 0;
            int skippedCount = 0;
            string LastCreated = "";

            if (!_unitOfWork.OrderRepository.Get().Any()) //If DB is empty just run without checking for doubles
            {
                foreach (var lo in liveorders)
                {
                    _unitOfWork.OrderRepository.AddOrUpdate(new Order { OrderGroupId = lo.OrderGroupId, Date = lo.Created });
                    addedCount++;
                    LastCreated = lo.Created.ToString();
                }
            }
            else //Check every order before saving to prevent doubles
            {
                foreach (var lo in liveorders)
                {
                    if (!_unitOfWork.OrderRepository.Get(o => o.OrderGroupId == lo.OrderGroupId).Any())
                    {
                        _unitOfWork.OrderRepository.AddOrUpdate(new Order { OrderGroupId = lo.OrderGroupId, Date = lo.Created });
                        addedCount++;
                        LastCreated = lo.Created.ToString();
                    }
                    else
                    {
                        skippedCount++;
                    }
                }
            }
            _unitOfWork.Save();
            var result = new
            {
                Added = addedCount,
                Skipped = skippedCount.ToString(),
                StartDate = year + " " + month
            };
            return result;
        }

        public object SeedLiveShipments(int year, int month)
        {
            IEnumerable<LiveShipment> liveshipments = _liveShipmentService.GetLiveShipmentsFor(year, month);

            int addedCount = 0;
            int skippedCount = 0;
            string LastCreated = "";

            if (!_unitOfWork.ShipmentRepository.Get().Any()) //If DB is empty just run without checking for doubles
            {
                foreach (var ls in liveshipments)
                {
                    _unitOfWork.ShipmentRepository.AddOrUpdate(new Shipment { No_ = ls.No_, PostingDate= ls.PostingDate});
                    addedCount++;
                    LastCreated = ls.PostingDate.ToString();
                }
            }
            else //Check every order before saving to prevent doubles
            {
                foreach (var ls in liveshipments)
                {
                    if (!_unitOfWork.ShipmentRepository.Get(s => s.No_== ls.No_).Any())
                    {
                        _unitOfWork.ShipmentRepository.AddOrUpdate(new Shipment { No_ = ls.No_, PostingDate = ls.PostingDate});
                        addedCount++;
                        LastCreated = ls.PostingDate.ToString();
                    }
                    else
                    {
                        skippedCount++;
                    }
                }
            }
            _unitOfWork.Save();
            var result = new
            {
                Added = addedCount,
                Skipped = skippedCount.ToString(),
                StartDate = year + " " + month
            };
            return result;
        }

        /*
         *  STATISTIK TILL STARTSIDAN ANGÅENDE ORDRAR
         *  flytta?
        */
        public object GetApplicationStats()
        {
            int totalOrders = _unitOfWork.OrderRepository.Count();
            int totalShipments = _unitOfWork.ShipmentRepository.Count();

            Order firstOrder = _unitOfWork.OrderRepository.GetOne(null, q => q.OrderBy(o => o.Date));
            string startDateOrders = (firstOrder != null) ? firstOrder.Date.ToString("yyyy-MM-dd hh:mm:ss") : "";
            Order lastOrder = _unitOfWork.OrderRepository.GetOne(null, q => q.OrderByDescending(o => o.Date));
            string endDateOrders = (lastOrder != null) ? lastOrder.Date.ToString("yyyy-MM-dd hh:mm:ss") : "";

            Shipment firstShipment = _unitOfWork.ShipmentRepository.GetOne(null, q => q.OrderBy(s => s.PostingDate));
            string startDateShipments = (firstShipment != null) ? firstShipment.PostingDate.ToString("yyyy-MM-dd hh:mm:ss") : "";
            Shipment last = _unitOfWork.ShipmentRepository.GetOne(null, q => q.OrderByDescending(s => s.PostingDate));
            string endDateShipments = (last != null) ? last.PostingDate.ToString("yyyy-MM-dd hh:mm:ss") : "";
            
            var stats = new {
                totalOrders = totalOrders,
                startDateOrders = startDateOrders,
                endDateOrders = endDateOrders,
                totalShipments = totalShipments,
                startDateShipments = startDateShipments,
                endDateShipments = endDateShipments
            };
            return stats;
        }

        
    }
}
