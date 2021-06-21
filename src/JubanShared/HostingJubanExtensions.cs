namespace JubanShared
{
    using Jubanlabs.JubanShared.Common.Config;
    using Jubanlabs.JubanShared.Logging;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public static class HostingJubanExtensions
    {
        public static IHost JubanWireUp(this IHost host)
        {
            var lf = host.Services.GetService<ILoggerFactory>();
            JubanLogger.SetLoggerFactory(lf);

            var config = host.Services.GetService<IConfiguration>();
            AppSettings.Instance.SetConfigRoot((IConfigurationRoot)config);
            return host;
        }
    }
}