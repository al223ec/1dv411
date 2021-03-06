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
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-mock.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/c3/c3.min.js",
                        "~/Scripts/d3/d3.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(                    
                        "~/App/appRoutes.js",
                        "~/App/app.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/app/controllers").Include(
                        "~/App/controllers/MainCtrl.js",
                        "~/App/controllers/DiagramCtrl.js",
                        "~/App/controllers/ScreenCtrl.js",
                        "~/App/controllers/LayoutCtrl.js",
                         "~/App/controllers/admin/AdminPagesCtrl.js",
                         "~/App/controllers/admin/AdminScreensCtrl.js",
                         "~/App/controllers/admin/AdminTemplatesCtrl.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/app/directives").Include(
                        "~/App/directives/partial.js",
                        "~/App/directives/angular-chart.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/app/services").Include(
                        "~/App/services/appService.js",
                        "~/App/services/LayoutScreenService.js",
                        "~/App/services/PartialHtmlService.js"
                        ));
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/angular-chart.css",
                      "~/Content/c3.css",
                      "~/Content/Site.css",
                      "~/Content/admin.css"));

            //För att minifiera alla filer
            //BundleTable.EnableOptimizations = true;
        }
    }
}
