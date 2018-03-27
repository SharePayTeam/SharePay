using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(SharePay.Web.Startup))]
namespace SharePay.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureAuth(app);
            ConfigureDI(config);
        }
    }
}
