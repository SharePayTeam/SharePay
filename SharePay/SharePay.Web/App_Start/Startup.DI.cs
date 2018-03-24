using Autofac;
using Owin;
using SharePay.Data;

namespace SharePay.Web
{
    public partial class Startup
    {
        public void ConfigureDI(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SharePayDbContext>().As<ISharePayDbContext>().InstancePerRequest();
            builder.Build();
        }
    }
}