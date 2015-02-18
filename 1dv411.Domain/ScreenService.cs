using _1dv411.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain
{
    public interface IScreenService : IService<Screen>
    {
        IEnumerable<Layout> GetLayoutsWithScreenId(int screenId);
    }
    public class ScreenService : ServiceBase, IScreenService
    {
        public IEnumerable<Screen> GetAll()
        {
            return _unitOfWork.ScreenRepository.Get();
        }
        public Screen GetById(int id)
        {
            return _unitOfWork.ScreenRepository.Get(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Layout> GetLayoutsWithScreenId(int screenId)
        {
            List<Layout> layouts = new List<Layout>();
            //Hämta alla relationsobjekt
            var layoutScreens = _unitOfWork.LayoutScreenRepository.Get(ls => ls.ScreenId == screenId, null, "Layout").ToList();
            //Lägg till all layouts till listan layouts 
            layoutScreens.ForEach(ls => layouts.Add(ls.Layout));
            return layouts;
        }
    }
}
