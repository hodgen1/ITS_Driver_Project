using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ITSDriverApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            // register the report routes      
            routes.MapPageRoute("ITS_Driver", "ITS_Driver", "~/ITS_Driver_Forms/ITS_Driver.aspx", false, null, new RouteValueDictionary(new { controller = new IncomingRequestConstraint() }));

        }
    }
}
