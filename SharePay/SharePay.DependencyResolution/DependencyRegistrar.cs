﻿using SharePay.DependencyResolution.Libraries;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace SharePay.DependencyResolution
{
    public static class DependencyRegistrar
    {
        private static bool isInitialized;
        private static readonly object locker = new object();

        private static Container Container { get; set; }

        public static void Initialize(HttpConfiguration config)
        {
            if (!isInitialized)
            {
                lock (locker)
                {
                    if (!isInitialized)
                    {
                        Configure(config);
                        InitializeLibraries();

                        isInitialized = true;
                    }
                }
            }
        }

        public static TType Resolve<TType>() where TType : class
        {
            using (AsyncScopedLifestyle.BeginScope(Container))
            {
                return Container.GetInstance<TType>();
            }
        }

        public static object Resolve(Type type)
        {
            using (AsyncScopedLifestyle.BeginScope(Container))
            {
                return Container.GetInstance(type);
            }
        }

        private static void Configure(HttpConfiguration config)
        {
            ConfigureContainer(config);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }

        private static void ConfigureContainer(HttpConfiguration config)
        {
            Container = new Container();

            Container.Options.DefaultLifestyle = Lifestyle.Scoped;
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            Container.Options.AllowOverridingRegistrations = true;
            Container.Options.PropertySelectionBehavior = new PropertyInjectionBehavior(Container);

            Container.RegisterPackages(AssemblyLocator.GetAllAssemblies());
            Container.RegisterMvcIntegratedFilterProvider();
            Container.RegisterMvcControllers(AssemblyLocator.GetAllAssemblies().ToArray());
            Container.RegisterWebApiControllers(config);

            Container.Verify();
        }

        private static void InitializeLibraries()
        {
            using (AsyncScopedLifestyle.BeginScope(Container))
            {
                var libraries = Container.GetAllInstances<ILibrary>();

                foreach (var library in libraries)
                {
                    if (library.IsEnabled)
                    {
                        library.Initialize();
                    }
                }
            }
        }
    }
}
