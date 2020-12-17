namespace Jubanlabs.JubanShared.Common.Test
{
    using Jubanlabs.JubanShared.Mongodb.Databases;
    using Jubanlabs.JubanShared.UnitTest;
    using MongoDB.Bson;
    using Xunit;
    using Xunit.Abstractions;

    public class TestMongodb : IClassFixture<BaseFixture>
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public TestMongodb(ITestOutputHelper outputHelper)
        {
            LoggingHelper.BindNLog(outputHelper);
        }

        [Fact]
        public void TestMongodbConnect()
        {
            var a = TestDatabase.Instance.TestCollection;
            long count = a.CountDocuments(new BsonDocument());
            Logger.ConditionalTrace(count);
        }

        [Fact]
        public void TestMongodbMisc()
        {
        }
    }
}