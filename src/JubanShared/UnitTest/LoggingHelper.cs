namespace Jubanlabs.JubanShared.UnitTest
{
    using NLog;
    using NLog.Config;
    using Xunit.Abstractions;

    public static class LoggingHelper
    {
        public static void BindNLog(ITestOutputHelper testOutputHelper)
        {
            // Step 1. Create configuration object
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration
            var consoleTarget = new XUnitTarget(testOutputHelper);

            config.AddTarget("xunit", consoleTarget);

            // Step 3. Set target properties
            // consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";

            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
        }
    }
}