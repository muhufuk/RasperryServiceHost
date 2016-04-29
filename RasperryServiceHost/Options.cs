using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace RasperryServiceHost
{
    internal class Options : IOptions
    {
        public Binding BindingType => new BasicHttpBinding();

        public int PortNumber => 6565;
    }
}
