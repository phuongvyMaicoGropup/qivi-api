using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly IMongoCollection<OrderItem> collection; 
        public OrderItemRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
            collection = catalogContext.GetCollection<OrderItem>("OrderItem");
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(string orderId)
        => await collection.Find(a => a.OrderId == orderId).ToListAsync();
    }
}

