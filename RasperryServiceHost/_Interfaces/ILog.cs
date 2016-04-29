namespace RasperryServiceHost
{
    interface ILog
    {
        void Info(string InfoMessage);

        void Warning(string WarningMessage);

        void Error(string ErrorMessage);
    }
}
