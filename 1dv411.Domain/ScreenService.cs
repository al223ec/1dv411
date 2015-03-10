using _1dv411.Domain.DAL;
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
        bool Save(Screen screen);
        bool Delete(int id);
    }

    public class ScreenService : IScreenService
    {
        private IUnitOfWork _unitOfWork;
        private IPageService _pageService;

        #region Constructor
        public ScreenService(IUnitOfWork unitOfWork, IPageService pageService)
        {
            _unitOfWork = unitOfWork;
            _pageService = pageService; 
        }
        #endregion

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
            var layoutScreens = _unitOfWork.PageScreenRepository.Get(ls => ls.ScreenId == screenId).ToList();
            //Lägg till all layouts till listan layouts 
            layoutScreens.ForEach(ls => pages.Add(_pageService.GetById(ls.PageId)));
            
            return pages.Count() > 0 ? pages : null;
        }


        public bool Save(Screen screen)
        {
            if (screen.PageScreens != null)
            {
                foreach (var pageScreen in screen.PageScreens)
                {
                    _unitOfWork.PageScreenRepository.AddOrUpdate(pageScreen);
                    if (pageScreen.Page.Template != null)
                    {
                        _unitOfWork.TemplateRepository.AddOrUpdate(pageScreen.Page.Template);
                    } 
                    _unitOfWork.PageRepository.AddOrUpdate(pageScreen.Page);
                }
            }   
            _unitOfWork.ScreenRepository.AddOrUpdate(screen);
            _unitOfWork.Save();
            return true;
        }

        public bool Delete(int id)
        {
            if (_unitOfWork.ScreenRepository.Remove(id)) 
            {
                _unitOfWork.Save();
                return true;
            }
            return false;           
        }
    }
}
