using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories.Interfaces
{
    
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }


}

