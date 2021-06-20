using System;
using Jubanlabs.JubanShared.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jubanlabs.JubanShared.Common.Test
{
    using Jubanlabs.JubanShared.Mongodb.Databases;
    using Jubanlabs.JubanShared.UnitTest;
    using MongoDB.Bson;

    [TestClass]
    public class TestMongodb {
        private static readonly ILogger<TestMongodb> Logger =  JubanLogger.GetLogger<TestMongodb>();

        public TestMongodb()
        {
        }

        [TestMethod]
        public void TestMongodbConnect()
        {
            var a = TestDatabase.Instance.TestCollection;
            long count = a.CountDocuments(new BsonDocument());
            Logger.LogTrace(count.ToString());
        }

        [TestMethod]
        public void TestMongodbMisc()
        {
        }
    }
}