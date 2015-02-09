using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1d411.Controllers
{
    public class AppController : Controller
    {
        //Denna kontroller serverar endast en SPA 
        // GET: App
        public ActionResult Index()
        {
            return View();
        }

        //this actionresult is temporary, just need the routing to work for now
        public ActionResult Month()
        {
            return new FilePathResult("../Views/App/exempel.html", "text/html");
        }
    }
}