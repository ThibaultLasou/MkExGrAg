using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AngularJS_CS
{
    /// <summary>
    /// Configurateur de table de routage.
    /// </summary>
    public class RouteConfig
    { 
		/// <summary>
		/// Configure la table de routage.
		/// </summary>
		/// <param name="routes">Collection de routes à enregistrer</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
