using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Animes.Club
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/css/bootstrap.css",
                 "~/css/font-awesome.css",
                 "~/css/animes.club.css"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/scripts/app/app.js",
                "~/scripts/app/controllers/menu.js",
                "~/scripts/app/controllers/search.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/scripts/bootstrap.js",
                "~/scripts/respond.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
               "~/scripts/angular.js",
               "~/scripts/angular-resource.js",
               "~/scripts/angular-route.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/components").Include(
                "~/scripts/typeahead.bundle.js",
                "~/scripts/handlebars-v2.0.0.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.unobtrusive*",
            //    "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            //    "~/Scripts/knockout-{version}.js",
            //    "~/Scripts/knockout.validation.js"));

            //bundles.Add(new ScriptBundle("~/bundles/app").Include(
            //    "~/Scripts/sammy-{version}.js",
            //    "~/Scripts/app/common.js",
            //    "~/Scripts/app/app.datamodel.js",
            //    "~/Scripts/app/app.viewmodel.js",
            //    "~/Scripts/app/home.viewmodel.js",
            //    "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //    "~/Scripts/modernizr-*"));

            

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}
