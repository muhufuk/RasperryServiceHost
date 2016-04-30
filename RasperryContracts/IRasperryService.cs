using System.ServiceModel;

namespace Ufuk.RasperryContracts
{
    [ServiceContract]
    public interface IRasperryService
    {
        [OperationContract(Action ="rasperry.ufuk.dummyMethod")]
        
        void DummyMethod();
    }
}
