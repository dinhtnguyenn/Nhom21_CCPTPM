using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SadiShop.Startup))]
namespace SadiShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
