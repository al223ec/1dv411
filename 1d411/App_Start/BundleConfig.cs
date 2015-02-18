﻿using System.Web;
using System.Web.Optimization;

namespace _1d411
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-mock.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/googleChartJs.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(                    
                        "~/App/services/appService.js",
                        "~/App/services/LayoutScreenService.js",
                        "~/App/services/PartialHtmlService.js",
                        "~/App/controllers/MainCtrl.js",
                        "~/App/controllers/ScreenCtrl.js",
                        "~/App/directives/partial.js",
                        "~/App/directives/diagram.js", 
                        "~/App/factories/chartFactory.js",
                        "~/App/appRoutes.js",
                        "~/App/app.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            //För att minifiera alla filer
            //BundleTable.EnableOptimizations = true;
        }
    }
}
