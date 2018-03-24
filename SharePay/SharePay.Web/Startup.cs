using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharePay.Web.Startup))]
namespace SharePay.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
