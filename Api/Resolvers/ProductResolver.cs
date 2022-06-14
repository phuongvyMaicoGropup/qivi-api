using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Resolvers
{
	
        [ExtendObjectType(typeof(Product))]
        public class ProductResolver
        {
            public Task<Product> GetProductInCartAsync(
              [Parent] CartItem cart,
              [Service] IProductRepository productRepository) => productRepository.GetByIdAsync(cart.ProductId);

        public Task<Product> GetProductInOrderAsync(
          [Parent] OrderItem order,
          [Service] IProductRepository productRepository) => productRepository.GetByIdAsync(order.ProductId);


    }

}

