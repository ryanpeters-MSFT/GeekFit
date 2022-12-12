using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekFit.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
            //routes.MapRoute("Workout", "{userId")
        }
    }
}
