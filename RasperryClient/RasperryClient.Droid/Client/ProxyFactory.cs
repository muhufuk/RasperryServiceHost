using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Ufuk.Rasperry.Common;

namespace RasperryClient.Droid.Client
{
    class ProxyFactory<T> : IProxyFactory where T : class
    {
        public Dictionary<T, ClientBase<T>> Client { get; set; }

        public ProxyFactory()
        {
            Client = new Dictionary<T, ClientBase<T>>();
        }

        public void AddClient(T client, IOptions options)
        {
            var client1 = new RasperryServiceClient(GetBinding(options.BindingType), CreateEndpointAddress(options));
        }

        private Binding GetBinding(string bindingName)
        {
            var binding = Activator.CreateInstance(typeof(Binding), bindingName);

            return (Binding)binding;
        }

        private EndpointAddress CreateEndpointAddress(IOptions options)
        {
            var uri = new UriBuilder(options.UriScheme, System.Net.IPAddress.Loopback.ToString(), options.PortNumber).Uri;
            var endpointaddress = new EndpointAddress(uri);
            return endpointaddress;
        }
    }
}