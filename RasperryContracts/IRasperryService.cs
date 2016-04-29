using System.ServiceModel;

namespace Ufuk.RasperryContracts
{
    [ServiceContract]
    public interface IRasperryService
    {
        [OperationContract]
        
        void DummyMethod();
    }
}
