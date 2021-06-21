using System;
using Jubanlabs.JubanShared.Logging;
using JubanShared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jubanlabs.JubanShared.Common.Test
{
    public class JubanTestBase
    {
        public JubanTestBase()
        {
            
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "testing");
            var host = Host.CreateDefaultBuilder()
                .ConfigureLogging((hostContext, loggingBuilder) => { loggingBuilder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace); })
                .Build().JubanWireUp();

            // ILoggerFactory loggerFactory =
            //     LoggerFactory.Create(builder => builder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace));
            // JubanLogger.SetLoggerFactory(loggerFactory);
            Console.WriteLine("JubanTestBase construction done");
        }
    }
}