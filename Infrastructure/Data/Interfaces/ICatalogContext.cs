using System;
using Core.Entities;
using MongoDB.Driver;

namespace Infrastructure.Data.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}

