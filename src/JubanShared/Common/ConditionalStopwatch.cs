namespace Jubanlabs.JubanShared.Common
{
    using System.Collections.Concurrent;
    using System.Diagnostics;

    public static class ConditionalStopwatch
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly ConcurrentDictionary<string, Stopwatch> SwDict = new ConcurrentDictionary<string, Stopwatch>();

        [Conditional("DEBUG")]
        public static void PunchIn(string key, string message = "")
        {
            var sw = Stopwatch.StartNew();
            SwDict[key + System.Threading.Thread.CurrentThread.ManagedThreadId] = sw;
            if (message != null && message.Length > 0)
            {
                Logger.ConditionalTrace(key + " " + sw.ElapsedMilliseconds + " "  + message);
            }
        }

        [Conditional("DEBUG")]
        public static void PunchOutAndIn(string key, string message = "")
        {
            Stopwatch sw = SwDict[key + System.Threading.Thread.CurrentThread.ManagedThreadId];
            if (sw != null)
            {
                Logger.ConditionalTrace(key + " " + sw.ElapsedMilliseconds + " "  + message);
                sw.Restart();
            }
        }

        [Conditional("DEBUG")]
        public static void PunchOut(string key, string message = "")
        {
            Stopwatch sw = SwDict[key + System.Threading.Thread.CurrentThread.ManagedThreadId];
            if (sw != null)
            {
                Logger.ConditionalTrace(key + " " + sw.ElapsedMilliseconds + " "  + message);

                sw.Stop();
                SwDict[key + System.Threading.Thread.CurrentThread.ManagedThreadId] = null;
            }
        }
    }
}