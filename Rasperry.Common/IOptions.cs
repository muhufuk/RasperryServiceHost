using System.ServiceModel.Channels;

namespace Ufuk.Rasperry.Common
{
    public interface IOptions
    {
        string BindingType { get; }

        int PortNumber { get; }

        string UriScheme { get; }
    }
}