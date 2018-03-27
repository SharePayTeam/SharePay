using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace SharePay.DependencyResolution.Packages
{
    public class CommonServicesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //container.Register<IApplicationUserManager, ApplicationUserManager>();
        }
    }
}
