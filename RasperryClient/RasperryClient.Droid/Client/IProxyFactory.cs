using Ufuk.Rasperry.Common;
using Ufuk.RasperryContracts;

namespace RasperryClient.Droid.Client
{
    interface IProxyFactory
    {
        void AddClient();

        IRasperryService GetClient();
    }
}