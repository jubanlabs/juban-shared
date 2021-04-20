namespace Jubanlabs.JubanShared.Common.Config
{
    using System;
    using System.IO;
    using System.Text;
    using Microsoft.Extensions.Configuration;

    public class AppSettings
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private static readonly Lazy<AppSettings> LazyObj =
            new Lazy<AppSettings>(
            () => new AppSettings());

        private AppSettings() => this.LoadConfig();

        public static AppSettings Instance
        {
            get { return LazyObj.Value; }
        }

        public IConfigurationRoot Config { get; private set; }

        public string GetValue(string key)
        {
            return this.Config[key];
        }

        private void LoadConfig()
        {
            Logger.ConditionalTrace("loading appsettings");
            AppSession.Instance.EnvironmentVariables.TryGetValue("JUBAN_EXTRA_CONFIG_FOLDER", out string extraConfigFolder);

            AppSession.Instance.EnvironmentVariables.TryGetValue("JUBAN_CONFIG", out string extraConfigBlock);
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppSession.Instance.WorkingDir)
                .AddJsonFile($"appsettings.json", true, false)
                .AddJsonFile($"appsettings." + AppSession.Instance.GetEnvironmentName() + ".json", true, false)
                .AddJsonFile($"juban.appsettings.json", true, false)
                .AddJsonFile($"juban.appsettings." + AppSession.Instance.GetEnvironmentName() + ".json", true, false);
            if (extraConfigFolder != null)
            {
                Logger.ConditionalTrace("loading extra config from " + extraConfigFolder);
                //Logger.ConditionalTrace(File.Exists(Path.Combine(AppSession.Instance.EnvironmentVariables["JUBAN_EXTRA_CONFIG_FOLDER"], $"appsettings.json")));
                builder.AddJsonFile(Path.Combine(AppSession.Instance.EnvironmentVariables["JUBAN_EXTRA_CONFIG_FOLDER"], $"appsettings.json"), true, false)
                    .AddJsonFile(Path.Combine(AppSession.Instance.EnvironmentVariables["JUBAN_EXTRA_CONFIG_FOLDER"], $"appsettings." + AppSession.Instance.GetEnvironmentName() + ".json"), true, false)
                    .AddJsonFile(Path.Combine(AppSession.Instance.EnvironmentVariables["JUBAN_EXTRA_CONFIG_FOLDER"], $"juban.appsettings.json"), true, false)
                    .AddJsonFile(Path.Combine(AppSession.Instance.EnvironmentVariables["JUBAN_EXTRA_CONFIG_FOLDER"], $"juban.appsettings." + AppSession.Instance.GetEnvironmentName() + ".json"), true, false);
            }

            if (extraConfigBlock != null)
            {
                using MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(extraConfigBlock));
                builder.AddJsonStream(stream: ms);
                this.Config = builder.Build();
            }
            else
            {
                this.Config = builder.Build();
            }
        }
    }
}