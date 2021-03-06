using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;
using CrossOver.DependencyResolution.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CrossOver.DependencyResolution.App_Start.DependencyResolutionWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CrossOver.DependencyResolution.App_Start.DependencyResolutionWebActivator), "Shutdown")]

namespace CrossOver.DependencyResolution.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class DependencyResolutionWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}