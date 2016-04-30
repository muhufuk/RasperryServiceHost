using Microsoft.Practices.Unity;

namespace RasperryClient.Droid._DependencyInjection
{
    internal class RasperryClientContainer : IRasperryClientContainer
    {

        public RasperryClientContainer()
        {
            IUnityContainer container = new UnityContainer();
        }

        public T Resolve<T>()
        {
            return default(T);    
        }
    }
}