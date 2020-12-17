namespace Jubanlabs.JubanShared.Mongodb
{
    using MongoDB.Driver;

    public abstract class MgDatabase
    {
        protected MgDatabase()
        {
            this.InitCollections();
        }

        public abstract void InitCollections();

        public IMongoDatabase GetDatabase()
        {
            return MongoClientContainer.Get(this.GetServerKey()).GetDatabase(this.GetDatabaseName());
        }

        protected abstract string GetDatabaseName();

        protected abstract string GetServerKey();
    }
}