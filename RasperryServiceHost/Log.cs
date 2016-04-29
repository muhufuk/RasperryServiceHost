using System;

namespace RasperryServiceHost
{
    internal class Log : ILog
    {
        public void Info(string InfoMessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(InfoMessage);
        }

        public void Warning(string WarningMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(WarningMessage);
        }

        public void Error(string ErrorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMessage);
        }
    }
}
