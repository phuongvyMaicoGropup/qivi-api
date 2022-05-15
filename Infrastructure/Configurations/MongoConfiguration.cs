using System;
namespace Infrastructure.Configurations
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";
        public string Database { get; set; } = "catalogdb"; 
    }
}

