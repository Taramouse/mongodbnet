using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDB.Net
{
    class Program
    {
        private static MongoClient client;
        private static IMongoCollection<BsonDocument> collection;
        private static IMongoDatabase database;

        static void Main(string[] args)
        {
            // Connect to the server.
            client = new MongoClient("mongodb://localhost:27017");
            Console.WriteLine("Connecting to localhost:27017... ");
            Console.WriteLine("Connected.");

            // Connect to test database.
            database = client.GetDatabase("test");
            Console.WriteLine("Connected to 'test' database");

            // Get the database collection.
            getCollection();
            
            // Make console wait for user to close.
            Console.WriteLine("Press 'CTRL + C' to exit...");
            Console.Read();
        }

        static async void getCollection()
        {
            collection = database.GetCollection<BsonDocument>("testData");
            // Find all documents in collection and convert to a List
            Console.WriteLine("testData collection list:");
            await collection.Find(new BsonDocument()).ForEachAsync(d => Console.WriteLine(d));
      
        }
    }
}
