using System.ServiceModel.Channels;

namespace RasperryServiceHost
{
    public interface IOptions
    {
        Binding BindingType { get; }

        int PortNumber { get; }
    }
}