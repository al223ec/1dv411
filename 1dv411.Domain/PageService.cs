using _1dv411.Domain.DAL;
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

        bool CreatePage(Page page);

        bool SaveTemplate(Template template);
    }
    public class PageService : IPageService
    {
        private IUnitOfWork _unitOfWork; 
        private IDiagramService _diagramService;

        #region Constructor
        public PageService(IUnitOfWork unitOfWork, IDiagramService diagramService)
        {
            _unitOfWork = unitOfWork;
            _diagramService = diagramService; 
        }
        #endregion
        
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
                    var partial = partials[i]; //Linq till databas gillar inte att man användare paritals[i]

                    if (partial.PartialType == "Diagram")
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


        public bool CreatePage(Page page)
        {
            _unitOfWork.TemplateRepository.AddOrUpdate(page.Template);
            _unitOfWork.PageRepository.AddOrUpdate(page);
            _unitOfWork.Save();
            return true;
        }

        public bool SaveTemplate(Template template)
        {
            _unitOfWork.TemplateRepository.AddOrUpdate(template);
            _unitOfWork.Save();
            return true;
        }
    }
}
