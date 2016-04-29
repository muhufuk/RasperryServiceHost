using System.ServiceModel;

namespace RasperryServiceHost
{
    internal interface IRasperryServiceHostManager
    {
        void OpenHost();

        void ClostHost();

        CommunicationState GetState();
    }
}
