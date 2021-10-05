using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LightYear.WebUI.Startup))]
namespace LightYear.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
