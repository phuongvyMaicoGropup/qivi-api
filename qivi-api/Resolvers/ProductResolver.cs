using System;
using Core.Entities;
using Core.Repositories;

namespace qivi_api.Resolvers
{
	
        [ExtendObjectType(Name = "Product")]
        public class ProductResolver
        {
            public Task<Product> GetProductInCartAsync(
              [Parent] CartItem cart,
              [Service] IProductRepository productRepository) => productRepository.GetByIdAsync(cart.ProductId);
            
        
    }

}

