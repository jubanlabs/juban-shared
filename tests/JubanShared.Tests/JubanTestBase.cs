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
            var host = Host.CreateDefaultBuilder()
                .ConfigureLogging((hostContext, loggingBuilder) => { loggingBuilder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace); })
                .Build().JubanWireUp();

            Console.WriteLine("JubanTestBase construction done");
        }
    }
}