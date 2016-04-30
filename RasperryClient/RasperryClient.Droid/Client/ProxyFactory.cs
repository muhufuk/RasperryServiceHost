using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Ufuk.Rasperry.Common;
using Ufuk.RasperryContracts;

namespace RasperryClient.Droid.Client
{
    class ProxyFactory : IProxyFactory
    {
        private IRasperryService m_RasperryService;
        private readonly IOptions m_Options;

        public ProxyFactory(IOptions options)
        {
            m_Options = options;
        }

        public void AddClient()
        {
            m_RasperryService = new RasperryServiceClient(StringToBinding(m_Options.BindingType), CreateEndpointAddress(m_Options));
        }

        public IRasperryService GetClient()
        {
            return m_RasperryService;
        }

        private Binding GetBinding(string bindingName)
        {
            var binding = Activator.CreateInstance(typeof(Binding), bindingName);
            return (Binding)binding;
        }

        private Binding StringToBinding(string bindingName)
        {
            switch (bindingName)
            {
                case "BasicHttpBinding":
                    return new BasicHttpBinding();
                //case "NetTcpBinding":
                //    return new NetTcpBinding();
                default:
                    Console.WriteLine("Invalid Binding Type");
                    return null;
            }
        }

        private EndpointAddress CreateEndpointAddress(IOptions options)
        {
            var uri = new UriBuilder(options.UriScheme, "localhost", options.PortNumber,"wcf").Uri;
            var endpointaddress = new EndpointAddress(uri);
            return endpointaddress;
        }
    }
}