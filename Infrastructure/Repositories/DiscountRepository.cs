using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        private readonly IMongoCollection<Discount> collection;
        public DiscountRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
            collection = catalogContext.GetCollection<Discount>("Discount"); 
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscounts()
        {
            return await collection.Find(a => a.Active == true
            ).ToListAsync(); 
            
        }
    }
}

