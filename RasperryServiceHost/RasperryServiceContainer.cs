using Microsoft.Practices.Unity;

namespace RasperryServiceHost
{
    internal class RasperryServiceContainer
    {
        IUnityContainer container = new UnityContainer();
        public RasperryServiceContainer()
        {
            container.RegisterType<ILog, Log>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRasperryServiceHostManager, RasperryServiceHostManager>();
            container.RegisterType<IOptions, Options>(new ContainerControlledLifetimeManager());
            container.RegisterType<Program>();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();            
        }
    }
}
