﻿using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface ILayoutService : IService<Layout>
    {
        IEnumerable<string> GetAllLayoutNames();
    }
    public class LayoutService : ServiceBase, ILayoutService
    {
        public IEnumerable<string> GetAllLayoutNames()
        {
            return _unitOfWork.LayoutRepository
               .Get()
               .Select(l => l.Name)
               .OrderBy(s => s)
               .ToList();
        }
        public Layout GetById(int id)
        {
            var layout = _unitOfWork.LayoutRepository.Get(l => l.Id == id, null, "Partials").FirstOrDefault();

            //Får inte ut textContent utan måste explecit hämta de objekten 
            if (layout != null && layout.Partials != null)
            {
                var partials = layout.Partials.ToList();
                for (int i = 0; i < partials.Count; i++)
                {
                    if (partials[i].PartialType == "Text")
                    {
                        var textPartial = partials[i];
                        partials[i] = _unitOfWork.TextRepository.Get(t => t.Id == textPartial.Id, null, "TextContents").FirstOrDefault();
                    }
                }
                layout.Partials = partials;
            }
            return layout;
        }

        public IEnumerable<Layout> GetAll()
        {
            return _unitOfWork.LayoutRepository.Get();
        }
    }
}
