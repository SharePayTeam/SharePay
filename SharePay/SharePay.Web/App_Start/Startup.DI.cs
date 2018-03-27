using Microsoft.AspNet.Identity;
using Owin;
using System.Web.Http;
using SharePay.DependencyResolution;

namespace SharePay.Web
{
    public partial class Startup
    {
        //Configurating SimpleInjector
        public void ConfigureDI(HttpConfiguration config)
        {
            DependencyRegistar.Initialize(config);
        }
    }
}