namespace RasperryServiceHost
{
    interface IServiceHelper
    {
        void Execute(string exeName, string command, object[] args, int timeout = 60000);
    }
}
