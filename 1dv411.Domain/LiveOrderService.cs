﻿using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface ILiveOrderService
    {
        IEnumerable<LiveOrder> GetLiveOrdersSince(DateTime? limitByDate = null);
        IEnumerable<LiveOrder> GetLiveOrdersFor(int year, int month);
        IEnumerable<LiveOrder> Get(int offset = 0, int limit = 1000);

    }
    public class LiveOrderService : ILiveOrderService
    {
        private IUnitOfWork _unitOfWork;
        public LiveOrderService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<LiveOrder> GetLiveOrdersSince(DateTime? limitByDate = null)
        {
            Expression<Func<LiveOrder, bool>> dateFilter = null;
            if (limitByDate != null)
            {
                dateFilter = lo => lo.Created >= limitByDate.Value;
            }
            return _unitOfWork.LiveOrderRepository.Get(dateFilter, null, null, null);
        }

        public IEnumerable<LiveOrder> GetLiveOrdersFor(int year, int month)
        {
            Expression<Func<LiveOrder, bool>> dateFilter = lo => lo.Created.Year == year && lo.Created.Month == month;
            return _unitOfWork.LiveOrderRepository.Get(dateFilter, null, null, null);
        }
        
        public IEnumerable<LiveOrder> Get(int offset = 0, int limit = 1000)
        {
            
            return _unitOfWork.LiveOrderRepository.Get(null, q => q.OrderBy(lo => lo.Created), offset, limit);
        }
    }
}
