namespace RasperryServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RasperryServiceContainer container = new RasperryServiceContainer();
            container.Resolve<Program>();
        }

        public Program(IRasperryServiceHostManager serviceHostManager)
        {
            serviceHostManager.OpenHost();
        }
    }
}
