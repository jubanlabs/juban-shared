using Jubanlabs.JubanShared.Logging;
using Microsoft.Extensions.Logging;

namespace Jubanlabs.JubanShared.Common.Config
{
    using System;
    using System.IO;
    using System.Text;
    using Microsoft.Extensions.Configuration;

    public class AppSettings
    {
        private static readonly ILogger<AppSettings> Logger =  JubanLogger.GetLogger<AppSettings>();

        private static readonly Lazy<AppSettings> LazyObj =
            new Lazy<AppSettings>(
            () => new AppSettings());

        private AppSettings()
        {
        }

        public static AppSettings Instance
        {
            get { return LazyObj.Value; }
        }

        public IConfigurationRoot Config { get; private set; }

        public string GetValue(string key)
        {
            return this.Config[key];
        }

        public void SetConfigRoot(IConfigurationRoot configRoot)
        {
            this.Config = configRoot;
        }
    }
}