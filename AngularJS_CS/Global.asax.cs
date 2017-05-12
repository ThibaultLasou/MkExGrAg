using AngularJS_CS.Controllers;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AngularJS_CS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code qui s’exécute au démarrage de l’application
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();

                var rd = new RouteData();
                //rd.DataTokens["area"] = "Shared"; // In case controller is in another area
                rd.Values["controller"] = "Error";
                rd.Values["action"] = "Index";

                IController c = new ErrorController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }
    }
}