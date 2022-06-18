using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Queries
{
	[ExtendObjectType(nameof(Query))]

	public class DiscountQuery
	{
		public DiscountQuery()
		{
		}
	
		public Task<IEnumerable<Discount>> GetDiscountsAsync([Service] IDiscountRepository discountRepository) =>
			discountRepository.GetAllAsync();

		public Task<Discount> GetDiscountById(string id, [Service] IDiscountRepository discountRepository) =>
			discountRepository.GetByIdAsync(id);
		public Task<IEnumerable<Discount>> GetActiveDiscounts([Service] IDiscountRepository discountRepository) =>
			discountRepository.GetActiveDiscounts();

	}
}

