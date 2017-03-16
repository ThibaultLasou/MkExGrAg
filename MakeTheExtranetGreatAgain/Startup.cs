using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeTheExtranetGreatAgain.Startup))]
namespace MakeTheExtranetGreatAgain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
