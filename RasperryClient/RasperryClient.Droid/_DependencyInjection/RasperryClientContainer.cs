using Microsoft.Practices.Unity;
using RasperryClient.Droid.Client;
using Ufuk.Rasperry.Common;

namespace RasperryClient.Droid._DependencyInjection
{
    internal class RasperryClientContainer : IRasperryClientContainer
    {
        IUnityContainer container = new UnityContainer();
        public RasperryClientContainer()
        {
            container.RegisterType<IOptions, Options>();
            container.RegisterType<IProxyFactory, ProxyFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<MainActivity>();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}