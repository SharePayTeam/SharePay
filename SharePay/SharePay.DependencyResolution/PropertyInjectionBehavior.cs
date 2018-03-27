using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Reflection;

namespace SharePay.DependencyResolution
{
    public class PropertyInjectionBehavior : IPropertySelectionBehavior
    {
        private readonly ContainerOptions containerOptions;
        private readonly IPropertySelectionBehavior propertySelectionBehavior;

        internal PropertyInjectionBehavior(Container container)
        {
            containerOptions = container.Options;
            propertySelectionBehavior = container.Options.PropertySelectionBehavior;
        }

        public bool SelectProperty(Type implementationType, PropertyInfo propertyInfo) =>
            IsInjectable(implementationType, propertyInfo) || propertySelectionBehavior.SelectProperty(implementationType, propertyInfo);

        private bool IsInjectable(Type implementationType, PropertyInfo propertyInfo) =>
            IsInjectableProperty(propertyInfo) && CanBeResolved(implementationType, propertyInfo);

        private bool IsInjectableProperty(PropertyInfo propertyInfo) =>
            propertyInfo.CanWrite && propertyInfo.GetSetMethod(false)?.IsStatic == false;

        private bool CanBeResolved(Type implementationType, PropertyInfo propertyInfo) =>
            containerOptions.DependencyInjectionBehavior.GetInstanceProducer(new InjectionConsumerInfo(implementationType, propertyInfo), false) != null;
    }
}
