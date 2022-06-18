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
		public async Task<IEnumerable<CartItem>> GetAllCartBySessionIdAsync(string sessionId, [Service] ICartItemRepository cartItemRepository) =>
			await cartItemRepository.GetBySessionId(sessionId);

	
	}
}

