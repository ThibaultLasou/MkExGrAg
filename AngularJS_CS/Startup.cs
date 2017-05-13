using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AngularJS_CS.Startup))]
namespace AngularJS_CS
{
	public class Startup
	{
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}