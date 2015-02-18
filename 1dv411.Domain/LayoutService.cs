using _1dv411.Domain.DAL;
using _1dv411.Domain.DbEntities;
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
        private IDiagramService _diagramService;
        public LayoutService()
            : this(new UnitOfWork())
        { }
        public LayoutService(IUnitOfWork unitOfWork)
            : this(new UnitOfWork(), new DiagramService())
        { }
        public LayoutService(IUnitOfWork unitOfWork, IDiagramService diagramService)
        {
            _unitOfWork = unitOfWork;
            _diagramService = diagramService; 
        }
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
                layout.Partials = partials;
            }
            return layout;
        }

        public IEnumerable<Layout> GetAll()
        {
            return _unitOfWork.LayoutRepository.Get();
        }


        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _diagramService.Dispose();
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion
    }
}
