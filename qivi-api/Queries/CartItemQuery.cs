using System;
using Core.Entities;
using Core.Repositories;

namespace qivi_api.Queries
{
	[ExtendObjectType("Query")]
	public class CartItemQuery
	{
		public CartItemQuery()
		{
		}
		public async Task<IEnumerable<CartItem>> GetAllCartByUserIdAsync(string userId, [Service] ICartItemRepository cartItemRepository) =>
			await cartItemRepository.GetAllCartByUserId(userId);

	
	}
}

