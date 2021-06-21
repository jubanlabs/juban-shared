using System;
using System.Threading.Tasks;
using Jubanlabs.JubanShared.Common.Config;
using Jubanlabs.JubanShared.Logging;
using JubanShared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace testConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "local");
            var host = CreateHostBuilder(args).Build().JubanWireUp();
            var logger = JubanLogger.GetLogger<Program>();

            logger.LogInformation("hello from Jubanlabs");

            logger.LogInformation(AppSettings.Instance.Config.GetDebugView());
            logger.LogInformation(AppSettings.Instance.GetValue("JUBAN_ENV_1"));
            await host.RunAsync();
            ;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureLogging((hostContext, loggingBuilder) =>
                {
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices((hostContext, collection) =>
                {
                    //collection.AddSingleton<ICommandLineInterface, CommandLineInterface>();
                    //services.AddHostedService<Worker>();
                });
    }
}