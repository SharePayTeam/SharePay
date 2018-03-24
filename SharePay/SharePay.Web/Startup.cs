using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SharePay.Web.Startup))]
namespace SharePay.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureDI(app);
        }
    }
}
