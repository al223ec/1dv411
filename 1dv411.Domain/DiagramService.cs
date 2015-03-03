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
        IEnumerable<DiagramData> GetDiagramData(DiagramType? diagramType);
        IEnumerable<DiagramData> GetDataWithDiagramId(int id);

        //IEnumerable<DiagramData> GetWeekDiagramData();
        //IEnumerable<DiagramData> GetMonthDiagramData();
        //IEnumerable<DiagramData> GetQuarterDiagramData();
        //IEnumerable<DiagramData> GetYearDiagramData();

        object SeedLiveOrders(DateTime? limitSince = null);

        object GetApplicationStats();
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

        private IEnumerable<DiagramData> GetDiagramData(int numberOfDays, DateTime date, DateTime lastYear)
        {
            
            /* LINQ löser inte datum-formatering, får hämta all data inom ett intervall och manuellt sortera*/
            var diagramData = new List<DiagramData>();
            for (int i = 0; i < numberOfDays; i++)
            {
                diagramData.Add(new DiagramData{
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

        //TODO: Fixa
        public IEnumerable<DiagramData> GetDiagramData(DiagramType? diagramType)
        {
            /* Uppdaterar Order-data om det behövs */
            UpdateOrderData();
            /**/

            DateTime startDate = DateTime.Now;
            DateTime lastYear = DateTime.Now.AddYears(-1);
            int numberOfDays = 0;
            switch (diagramType)
            {
                case DiagramType.Week:
                    numberOfDays = 7;
                    startDate = TransformDateToMondayOfSameWeek(startDate);
                    lastYear = TransformDateToMondayOfSameWeekLastYear(startDate);
                    break;
                case DiagramType.Month:
                    numberOfDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    startDate = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                    lastYear = startDate.AddYears(-1);
                    break;
                case DiagramType.Quarter:
                    numberOfDays = CalculateDaysOfQuarter(startDate);
                    startDate = GetStartDateOfQuarter(startDate);
                    lastYear = startDate.AddYears(-1);
                    break;
                case DiagramType.Year:
                    numberOfDays = new DateTime(DateTime.Now.Year, 12, 31).DayOfYear;
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    lastYear = startDate.AddYears(-1);
                    break;
            }

            return GetDiagramData(numberOfDays, startDate, lastYear);
        }

        public IEnumerable<DiagramData> GetDataWithDiagramId(int id)
        {
            var diagram = _unitOfWork.DiagramRepository.Get(d => d.Id == id).FirstOrDefault(); 
            return diagram != null ? GetDiagramData(diagram.DiagramType)  : null; 
        }


        /*
         * NYA DIAGRAMDATAMETODER
         * 
        */
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
        public object SeedLiveOrders(DateTime? limitSince = null)
        {

            IEnumerable<LiveOrder> liveorders = _liveOrderService.GetLiveOrdersSince(limitSince.Value);

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
                StartDate = limitSince,
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
            
            Order first= _unitOfWork.OrderRepository.GetOne(null, q => q.OrderBy(o => o.Date));
            string startDate = (first != null) ? first.Date.ToString("yyyy-MM-dd hh:mm:ss") : "";
            
            Order last = _unitOfWork.OrderRepository.GetOne(null, q => q.OrderByDescending(o => o.Date));
            string endDate = (last != null) ? last.Date.ToString("yyyy-MM-dd hh:mm:ss") : "";
            
            var stats = new {
                totalOrders = totalOrders,
                startDate = startDate,
                endDate = endDate
            };
            return stats;
        }
    }
}
