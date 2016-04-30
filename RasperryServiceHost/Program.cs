using System.Threading;

namespace RasperryServiceHost
{
    internal class Program
    {
        private AutoResetEvent m_KeepAlive = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            RasperryServiceContainer container = new RasperryServiceContainer();
            container.Resolve<Program>();
        }

        public Program(IRasperryServiceHostManager serviceHostManager)
        {
            serviceHostManager.OpenHost();
            m_KeepAlive.WaitOne();
        }
    }
}
