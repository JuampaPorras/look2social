using Microsoft.Owin;
using Owin;
using SmartSocial.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace SmartSocial.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
