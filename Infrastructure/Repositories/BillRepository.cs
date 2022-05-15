using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
	public class BillRepository :  BaseRepository<Bill> , IBillRepository 
	{
        private readonly IMongoCollection<Bill> collection;
        public BillRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
            collection = catalogContext.GetCollection<Bill>("Bill");
        }

        public async Task<List<Bill>> GetAllBillByCustomerId(string customerId) =>
         await collection.Find(u => u.CustomerId == customerId).ToListAsync();

        public async Task<List<Bill>> GetAllNotSuccessBill()
            => await collection.Find(u => u.IsSuccess == false).ToListAsync();

        public async Task<List<Bill>> GetAllOwnsBill()
           => await collection.Find(u => u.AmountOwed != 0 ).ToListAsync();

    }
}

