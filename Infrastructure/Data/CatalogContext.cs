using System;
using Core.Entities;
using Infrastructure.Configurations;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase database;

        public CatalogContext(MongoDbConfiguration mongoDbConfiguration)
        {
            var client = new MongoClient(mongoDbConfiguration.ConnectionString);

            this.database = client.GetDatabase(mongoDbConfiguration.Database);

            //CatalogContextSeed.SeedData(this.database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }
    }
}

