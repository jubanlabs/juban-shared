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
            //Console.WriteLine("set logger factory");
            lf = loggerFactory;
        }

        public static ILogger<T> GetLogger<T>()
        {
            //Console.WriteLine("get logger lf:" + (lf == null) + " name:"+(typeof(T).FullName));
            return lf == null ? NullLogger<T>.Instance : lf.CreateLogger<T>();
            
        }

        public static ILogger GetLogger(string categoryName)
        {
            //Console.WriteLine("get logger lf:" + (lf == null)+ " name:"+categoryName);
            return lf == null ? NullLogger.Instance : lf.CreateLogger(categoryName);
        }
    }
}