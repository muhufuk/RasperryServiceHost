using System.ServiceModel;

namespace RasperryServiceHost
{
    [ServiceContract]
    interface IRasperryService
    {
        [OperationContract]
        
        void DummyMethod();
    }
}
