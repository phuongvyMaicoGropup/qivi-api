using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Queries
{
	[ExtendObjectType(nameof(Query))]
	public class ProductQuery
	{
		public ProductQuery()
		{
		}
		public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
			productRepository.GetAllAsync();

		public Task<Product> GetProductById(string id, [Service] IProductRepository productRepository) =>
			productRepository.GetByIdAsync(id);
		public Task<IEnumerable<Product>> GetProductByDiscountId(string id, [Service] IProductRepository productRepository) =>
			productRepository.GetByDiscountId(id);

	}
}

