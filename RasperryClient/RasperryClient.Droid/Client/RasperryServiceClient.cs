using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Ufuk.RasperryContracts;

namespace RasperryClient.Droid.Client
{
    internal class RasperryServiceClient : ClientBase<IRasperryService>, IRasperryService
    {
        public RasperryServiceClient(Binding binding, EndpointAddress endpointAddress) : base(binding, endpointAddress)
        {
        }

        public void DummyMethod()
        {
            Channel.DummyMethod();
        }
    }
}