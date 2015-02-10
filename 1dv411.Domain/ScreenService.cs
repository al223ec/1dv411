﻿using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IScreenService
    {
        IEnumerable<Screen> GetScreens();

        IEnumerable<LayoutScreen> GetLayoutScreens();
    }
    public class ScreenService : ServiceBase, IScreenService
    {
        public IEnumerable<Screen> GetScreens()
        {
            return _unitOfWork.ScreenRepository.Get(s => s.Id == 1).ToList(); 
        }

        public IEnumerable<LayoutScreen> GetLayoutScreens()
        {
            //För att implementera eager loading, hämta ut object som är specad
            return _unitOfWork.LayoutScreenRepository.Get(null, null, "Screen, Layout").Take(10).ToList();
        }
    }
}
