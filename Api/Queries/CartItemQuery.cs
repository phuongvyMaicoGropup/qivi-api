using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Queries
{
	[ExtendObjectType(nameof(Query))]
	public class CartItemQuery
	{
		public CartItemQuery()
		{
		}
		public async Task<IEnumerable<CartItem>> GetAllCartByUserIdAsync(string userId, [Service] ICartItemRepository cartItemRepository) =>
			await cartItemRepository.GetAllCartByUserId(userId);

	
	}
}

