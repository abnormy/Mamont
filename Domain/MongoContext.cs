using MongoDB.Driver;

namespace Domain
{
    public static class MongoContext
    {
        static MongoContext()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            Db = server.GetDatabase("Mamont");
        }

        public static MongoDatabase Db { get; private set; }
    }
}