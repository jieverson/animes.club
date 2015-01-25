using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Animes.Club
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "API",
                url: "api/{controller}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "View",
                url: "view/{folder}/{file}",
                defaults: new { controller = "View", action = "Template", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "View",
            //    url: "view/{controller}/{action}",
            //    defaults: new { id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Angular",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
