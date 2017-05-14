using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AngularJS_CS.Startup))]
namespace AngularJS_CS
{
    /// <summary>
    /// Classe de démarrage appelée automatiquement par le compilateur, peu après le démarrage du serveur.
    /// </summary>
	public class Startup
	{
        /// <summary>
        /// Configure les packages nécessitant des données dynamiques, relatives à la session du serveur.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}