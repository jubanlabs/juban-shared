namespace Jubanlabs.JubanShared.Common
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;

    public class AppSession
    {
        private static readonly Lazy<AppSession> LazyObj =
            new Lazy<AppSession>(
            () => new AppSession());

        private readonly string host;

        private AppSession()
        {
            this.WorkingDir = System.AppContext.BaseDirectory;
            this.host = StripHostName(Environment.MachineName);
            this.PID = Process.GetCurrentProcess().Id;

            this.InitEnvironmentVariables();
        }

        public static AppSession Instance
        {
            get { return LazyObj.Value; }
        }

        public string ProcessInfo
        {
            get { return this.host + "[" + this.PID + "]"; }
        }

        public string WorkingDir { get; set; }

        public ConcurrentDictionary<string, string> EnvironmentVariables { get; private set; }

        public int PID { get; }

        public static string StripHostName(string str)
        {
            if (str == null)
            {
                return string.Empty;
            }

            return str.IndexOf(".", StringComparison.Ordinal) <= 0 ?
                str :
                str.Substring(0, str.IndexOf(".", StringComparison.Ordinal));
        }

        public string GetEnvironmentName()
        {
            if (!this.EnvironmentVariables.Keys.Contains("JUBAN_ENVIRONMENT_NAME"))
            {
                throw new Exception("environment name not specified.");
            }
            else
            {
                return this.EnvironmentVariables["JUBAN_ENVIRONMENT_NAME"];
            }
        }

        public void SetEnvironmentName(string env)
        {
            this.EnvironmentVariables["JUBAN_ENVIRONMENT_NAME"] = env;
        }

        private void InitEnvironmentVariables()
        {
            this.EnvironmentVariables = TransformEnvironmentVariables.Load(Environment.GetEnvironmentVariables());
        }
    }
}