using CrossOver.DependencyResolution.App_Start;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace CrossOver.DependencyResolution
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            UnityConfig.RegisterTypes(container);
			
            // register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());
        }
    }    
}