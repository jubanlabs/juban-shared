namespace Jubanlabs.JubanShared.Mongodb.Databases
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class TestDatabase : MgDatabase
    {
        private static readonly Lazy<TestDatabase> LazyObj =
           new Lazy<TestDatabase>(
           () => new TestDatabase());

        public static TestDatabase Instance
        {
            get { return LazyObj.Value; }
        }

        public IMongoCollection<BsonDocument> TestCollection { get; set; }

        public override void InitCollections()
        {
            this.TestCollection = this.GetDatabase().GetCollection<BsonDocument>("test");
        }

        protected override string GetDatabaseName()
        {
            return "test";
        }

        protected override string GetServerKey() => "test-mongo";
    }
}