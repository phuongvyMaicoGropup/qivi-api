using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Serilog;

namespace Infrastructure.Repositories
{
	public class BillRepository :  BaseRepository<Bill> , IBillRepository 
	{
        private readonly ILogger<IBillRepository> _logger;
        private readonly IMongoCollection<Bill> collection;
        public BillRepository(ICatalogContext catalogContext, ILogger<IBillRepository> logger) : base(catalogContext)
        {
            _logger = logger;
            collection = catalogContext.GetCollection<Bill>("Bill");
        }

        public async Task<List<Bill>> GetAllBillByCustomerId(string customerId)
        {
            _logger.LogInformation("Get all bill from repository");
            return await collection.Find(u => u.CustomerId == customerId).ToListAsync();
            

        }

        public async Task<List<Bill>> GetAllNotSuccessBill()
        {
            _logger.LogInformation("Get all not success bill from repository");
        return  await collection.Find(u => u.IsSuccess == false).ToListAsync();

        }

        public async Task<List<Bill>> GetAllOwnsBill()
        {
            _logger.LogInformation("Get all owns bill from repository");

          return await collection.Find(u => u.AmountOwed != 0).ToListAsync();

        }

    }
}

