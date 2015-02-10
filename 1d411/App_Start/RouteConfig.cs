using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _1d411
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //specify route for diagramdata for month
            routes.MapRoute(
                name: "testmonthDiagram",
                url: "test/monthDiagram",
                defaults: new { controller = "App", action = "Month" }

                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "App", action = "Index", id = UrlParameter.Optional }
            );

           // routes.AppendTrailingSlash = true;
        }

       
    }
}
