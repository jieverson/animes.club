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
                 //"~/css/alertify.bootstrap.css",
                 "~/css/alertify.default.css",
                 "~/css/animes.club.css"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/scripts/app/app.js",
                "~/scripts/app/controller/app.js",
                "~/scripts/app/controller/menu.js",
                "~/scripts/app/controller/search.js",
                "~/scripts/app/controller/login.js",
                "~/scripts/app/controller/register.js",
                "~/scripts/app/controller/user.js",
                "~/scripts/app/controller/anime.js",
                "~/scripts/app/controller/my-list.js",
                "~/scripts/app/service/auth.js",
                "~/scripts/app/service/session.js",
                "~/scripts/app/service/anime.js",
                "~/scripts/app/enum/AUTH_EVENTS.js",
                "~/scripts/app/enum/USER_ROLES.js"
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
                "~/scripts/alertify.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //    "~/Scripts/modernizr-*"));
        }
    }
}
