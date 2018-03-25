using Autofac;
using Microsoft.AspNet.Identity;
using Owin;
using SharePay.Data;
using SharePay.Entities.Data;

namespace SharePay.Web
{
    public partial class Startup
    {
        public void ConfigureDI(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SharePayDbContext>().As<ISharePayDbContext>().InstancePerRequest();
            builder.RegisterType<UserStore>().As(typeof(IUserStore<User, int>)).InstancePerRequest();
            builder.Build();
        }
    }
}