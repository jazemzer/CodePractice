using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyCast.DependencyInjection
{

    /// <summary>
    /// Using Unity - https://msdn.microsoft.com/en-us/library/dn178463(v=pandp.30).aspx
    /// </summary>
    public static class DependencyInjector
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();
        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }
        public static void InjectStub<I>(I instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }
        public static T Resolve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}
