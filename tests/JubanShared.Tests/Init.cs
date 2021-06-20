using System;
using Jubanlabs.JubanShared.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jubanlabs.JubanShared.Common.Test
{
    [TestClass]
    public class Init
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Environment.SetEnvironmentVariable("JUBAN_ENVIRONMENT_NAME", "testing");
            ILoggerFactory loggerFactory =
                LoggerFactory.Create(builder => builder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace));
            JubanLogger.SetLoggerFactory(loggerFactory);

            Console.WriteLine("AssemblyInitialize");
        }
    }
}