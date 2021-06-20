using Jubanlabs.JubanShared.Logging;
using Microsoft.Extensions.Logging;

namespace Jubanlabs.JubanShared.Common.Test
{
    using Jubanlabs.JubanShared.Mongodb.Databases;
    using Jubanlabs.JubanShared.UnitTest;
    using MongoDB.Bson;
    using Xunit;
    using Xunit.Abstractions;

    public class TestMongodb : IClassFixture<BaseFixture>
    {
        private static readonly ILogger<TestMongodb> Logger =  JubanLogger.GetLogger<TestMongodb>();

        public TestMongodb(ITestOutputHelper outputHelper)
        {
            
        }

        [Fact]
        public void TestMongodbConnect()
        {
            var a = TestDatabase.Instance.TestCollection;
            long count = a.CountDocuments(new BsonDocument());
            Logger.LogTrace(count.ToString());
        }

        [Fact]
        public void TestMongodbMisc()
        {
        }
    }
}