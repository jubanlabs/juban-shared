using Microsoft.Extensions.Logging;

namespace Jubanlabs.JubanShared.Logging
{
    public class LoggingTest
    {
        private static readonly ILogger<LoggingTest> Logger =  JubanLogger.GetLogger<LoggingTest>();

        public void TestLoggingOutput()
        {
            Logger.LogInformation("log info");
            
            Logger.LogTrace("log trace");
            Logger.LogDebug("log debug");
        }
    }
}