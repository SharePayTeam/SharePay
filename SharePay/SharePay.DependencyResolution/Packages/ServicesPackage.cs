using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Packaging;
using SharePay.Services.Interfaces;
using SharePay.Services;

namespace SharePay.DependencyResolution.Packages
{
    public class ServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //container.Register<IApplicationUserManager, ApplicationUserManager>();
        }
    }
}
