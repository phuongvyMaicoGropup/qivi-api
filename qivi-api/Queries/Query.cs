using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate;

namespace qivi_api.Queries
{
    public class Query
    {
        public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
            productRepository.GetAllAsync();

        public Task<Product> GetProductById(string id, [Service] IProductRepository productRepository) =>
            productRepository.GetByIdAsync(id);

        // Add any queries you want here..
        // - Get categories
        // - Get products by category
        // - etc
    }
}

