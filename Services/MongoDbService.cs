using MongoDB.Driver;
using DotNetEnv;

namespace _.Services
{
    public static class MongoDbService
    {
        public static IMongoDatabase InitializeMongoDatabase()
        {
            
            Env.Load();

            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
            var dbName = Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(dbName))
            {
                throw new InvalidOperationException("MongoDB connection string or database name is not provided.");
            }

            var client = new MongoClient(connectionString);
            return client.GetDatabase(dbName);
        }
    }
}