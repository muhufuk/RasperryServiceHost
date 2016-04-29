using System;
using Ufuk.RasperryContracts;

namespace RasperryServiceHost
{
    internal class RasperryService : IRasperryService
    {
        public void DummyMethod()
        {
            Console.WriteLine("Hello World");
        }
    }
}
