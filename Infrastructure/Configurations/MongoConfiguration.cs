using System;
namespace Infrastructure.Configurations
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; } = "mongodb+srv://andreatran2002:123Phuongvy@cluster0.to4ss.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        public string Database { get; set; } = "Cluster0"; 
    }
}

