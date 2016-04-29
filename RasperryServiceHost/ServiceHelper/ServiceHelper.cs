using System.Diagnostics;

namespace RasperryServiceHost
{
    internal class ServiceHelper : IServiceHelper
    {
        private readonly ILog m_Log;
        public ServiceHelper(ILog log)
        {
            m_Log = log;
        }

        public void Execute(string exeName, string command, object[] args, int timeout = 60000)
        {
            if (string.IsNullOrEmpty(command)) return;

            var arguments = string.Format(command, args);
            m_Log.Info($"Executing: {exeName} {arguments}");

            var startInfo = new ProcessStartInfo
            {
                FileName = exeName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (var p = new Process { StartInfo = startInfo })
            {
                p.Start();

                using (var std = p.StandardOutput)
                {
                    while (!std.EndOfStream)
                    {
                        var line = std.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        m_Log.Info($"[{exeName}] -> {line.Trim()}");
                    }
                }

                var isTimedOut = !p.WaitForExit(timeout);
                if (isTimedOut)
                {
                    m_Log.Error($"{exeName} failed due to timeout.");
                    return;
                }

                using (var err = p.StandardError)
                {
                    while (!err.EndOfStream)
                    {
                        var line = err.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        m_Log.Error($"[{exeName}] -> {line.Trim()}");
                    }
                }
                if (p.ExitCode == 0)
                {
                    m_Log.Info($"{exeName} succeeded.");
                }
                else
                {
                    m_Log.Warning($"{exeName} failed with exit code {p.ExitCode}.");
                }
            }
        }
    }
}
