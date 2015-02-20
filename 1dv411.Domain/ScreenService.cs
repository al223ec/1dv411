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
        IEnumerable<Page> GetPagesWithScreenId(int screenId);

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

        public IEnumerable<Page> GetPagesWithScreenId(int screenId)
        {
            List<Page> pages = new List<Page>();
            //Hämta alla relationsobjekt
            var layoutScreens = _unitOfWork.PageScreenRepository.Get(ls => ls.ScreenId == screenId, null, "Page").ToList();
            //Lägg till all layouts till listan layouts 
            layoutScreens.ForEach(ls => pages.Add(ls.Page));
            return pages.Count() > 0 ? pages : null;
        }
    }
}
