using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Animes.Club
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/css/bootstrap/bootstrap.css",
                 "~/css/font-awesome.css",
                 "~/css/alertify.core.css",
                 "~/css/alertify.default.css",
                 "~/css/animes.club.css"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/app.js",
                "~/app/controller/app.js",
                "~/app/controller/menu.js",
                "~/app/controller/search.js",
                "~/app/controller/trending.js",
                "~/app/controller/login.js",
                "~/app/controller/register.js",
                "~/app/controller/user.js",
                "~/app/controller/anime.js",
                "~/app/controller/my-list.js",
                "~/app/service/auth.js"
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
                "~/scripts/handlebars-v2.0.0.js",
                "~/scripts/alertify.js",
                "~/scripts/ui-bootstrap-tpls-0.12.0.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //    "~/Scripts/modernizr-*"));
        }
    }
}
