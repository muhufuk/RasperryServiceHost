using System;
using System.Net;
using System.ServiceModel;
using Ufuk.RasperryContracts;

namespace RasperryServiceHost
{
    internal sealed class RasperryServiceHostManager : IRasperryServiceHostManager, IDisposable
    {
        private readonly ServiceHost m_ServiceHost;
        private readonly ILog m_Log;
        private readonly IOptions m_Options;

        public RasperryServiceHostManager(ILog log, IOptions options)
        {
            m_Log = log;
            m_Options = options;
            m_ServiceHost = new ServiceHost(typeof(RasperryService));
            AddEndpointToServiceHost<IRasperryService>();
        }

        public void OpenHost()
        {
            try
            {
                m_ServiceHost.Open();
                m_Log.Info($"Host is opened and listening {BuidEndPointUri()}:");
            }
            catch (CommunicationObjectFaultedException)
            {
                m_Log.Error("CommunicationObjectFaultedException");
            }
            catch (AddressAccessDeniedException)
            {
                m_Log.Error($"You dont have access right to register to given port {m_Options.PortNumber}");
            }
        }

        public void ClostHost()
        {
            m_Log.Info("Host is closing");
            m_ServiceHost.Close();
        }

        public CommunicationState GetState()
        {
            return m_ServiceHost.State;
        }

        private void AddEndpointToServiceHost<T>() where T : class
        {
            m_ServiceHost.AddServiceEndpoint(typeof(T), m_Options.BindingType, BuidEndPointUri());
        }

        private Uri BuidEndPointUri()
        {
            return  new UriBuilder(Uri.UriSchemeHttp, IPAddress.Loopback.ToString(), m_Options.PortNumber).Uri;
        }

        public void Dispose()
        {
            m_ServiceHost?.Close();
        }
    }
}
