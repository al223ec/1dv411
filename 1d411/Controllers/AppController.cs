using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1d411.Controllers
{
    public class AppController : Controller
    {
        //Denna kontroller serverar endast SPA 
        // GET: App
        public ActionResult Index()
        {
            return View();
        }
    }
}