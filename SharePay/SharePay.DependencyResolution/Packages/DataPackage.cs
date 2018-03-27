﻿using Microsoft.AspNet.Identity;
using SharePay.Data;
using SharePay.Data.Interfaces;
using SharePay.Entities.Data;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.DependencyResolution.Packages
{
    public class DataPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            #region DbContext

            container.Register<ISharePayDbContext, SharePayDbContext>();

            #endregion

            #region Repositories

            container.Register<IUserStore<User, int>, UserStore>();

            #endregion

        }
    }
}
