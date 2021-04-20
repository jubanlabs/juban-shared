namespace Jubanlabs.JubanShared.Common
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    public static class TransformEnvironmentVariables
    {
        public static ConcurrentDictionary<string, string> Load(IDictionary dict)
        {
            Contract.Requires(dict != null);
            ConcurrentDictionary<string, string> envList = new ConcurrentDictionary<string, string>();
            foreach (var item in dict.Keys)
            {
                envList.TryAdd((string)item, (string)dict[(string)item]);
            }

            // if (!envList.Keys.Contains("JUBAN_ENVIRONMENT_NAME"))
            // {
            //     envList.TryAdd("JUBAN_ENVIRONMENT_NAME", "testing");
            // }

            return envList;
        }
    }
}