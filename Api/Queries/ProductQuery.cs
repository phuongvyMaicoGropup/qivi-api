using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Queries
{
	[ExtendObjectType(Name ="Query")]
	public class ProductQuery
	{
		public ProductQuery()
		{
		}
		public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
			productRepository.GetAllAsync();

		public Task<Product> GetProductById(string id, [Service] IProductRepository productRepository) =>
			productRepository.GetByIdAsync(id);

	}
}

