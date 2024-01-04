using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoDbContext(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromConnectionString(configuration.GetSection("DatabaseSettings")["ConnectionString"]);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings")["DatabaseName"]);
            Knights = database.GetCollection<Knight>(configuration.GetSection("DatabaseSettings")["CollectionName"]);
            KnightsContextSeed.SeedData(Knights);
        }
        public IMongoCollection<Knight> Knights { get; }
    }
}
