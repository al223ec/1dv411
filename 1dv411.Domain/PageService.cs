﻿using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IPageService : IService<Page>
    {
        IEnumerable<string> GetAllPageNames();
    }
    public class PageService : IPageService
    {
        private IUnitOfWork _unitOfWork; 

        private IDiagramService _diagramService;
        public PageService(IUnitOfWork unitOfWork, IDiagramService diagramService)
        {
            _unitOfWork = unitOfWork;
            _diagramService = diagramService; 
        }
        public IEnumerable<string> GetAllPageNames()
        {
            return _unitOfWork.PageRepository
               .Get()
               .Select(l => l.Name)
               .OrderBy(s => s)
               .ToList();
        }
        public Page GetById(int id)
        {
            var page = _unitOfWork.PageRepository.Get(l => l.Id == id, null, "Partials").FirstOrDefault();

            //Får inte ut textContent utan måste explecit hämta de objekten 
            if (page != null && page.Partials != null)
            {
                var partials = page.Partials.ToList();
                for (int i = 0; i < partials.Count; i++)
                {
                    var partial = partials[i]; //Gillar inte att man användare paritals[i]

                    if (partial.PartialType == "Text")
                    {
                        partials[i] = _unitOfWork.TextRepository.Get(t => t.Id == partial.Id, null, "TextContents").FirstOrDefault();
                    }
                    else if (partial.PartialType == "Diagram")
                    {
                        var diagram = partial as Diagram; 
                        diagram.Data = _diagramService.GetDiagramData(diagram.DiagramType);
                        partials[i] = diagram; 
                    }
                    
                }
                page.Partials = partials;
            }
            return page;
        }

        public IEnumerable<Page> GetAll()
        {
            return _unitOfWork.PageRepository.Get();
        }
    }
}
