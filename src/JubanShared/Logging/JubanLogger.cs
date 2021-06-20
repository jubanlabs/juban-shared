using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Jubanlabs.JubanShared.Logging
{
    public class JubanLogger
    {
        private static ILoggerFactory lf ;

        public static void SetLoggerFactory(ILoggerFactory loggerFactory)
        {
            lf = loggerFactory;
        }

        public static ILogger<T> GetLogger<T>()
        {
            return lf == null ? NullLogger<T>.Instance : lf.CreateLogger<T>();
        }

        public static ILogger GetLogger(string categoryName)
        {
            return lf == null ? NullLogger.Instance : lf.CreateLogger(categoryName);
        }
    }
}