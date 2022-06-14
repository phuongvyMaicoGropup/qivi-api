using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;

namespace Infrastructure.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}

