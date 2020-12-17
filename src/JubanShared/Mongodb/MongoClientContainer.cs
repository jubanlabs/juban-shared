namespace Jubanlabs.JubanShared.Mongodb
{
    using System;
    using System.Collections.Concurrent;
    using Jubanlabs.JubanShared.Common.Config;
    using MongoDB.Driver;

    public static class MongoClientContainer
    {
        private static readonly ConcurrentDictionary<string, Lazy<MongoClient>> Container = new ConcurrentDictionary<string, Lazy<MongoClient>>();

        public static MongoClient Get(string key)
        {
            return Container.GetOrAdd(key, x => new Lazy<MongoClient>(
               () => { return new MongoClient(AppSettings.Instance.GetValue(key)); })).Value;
        }
    }
}