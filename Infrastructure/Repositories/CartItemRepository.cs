using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
	public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        private readonly IMongoCollection<CartItem> collection; 
        public CartItemRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
            collection = catalogContext.GetCollection<CartItem>("CartItem"); 
        }

        public async Task<List<CartItem>> GetBySessionId(string sessionId)
        {
            return await collection.Find(u => u.SessionId == sessionId).ToListAsync();
        }
        
            
        
    }

}

