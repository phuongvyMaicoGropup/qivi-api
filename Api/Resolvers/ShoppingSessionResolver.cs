using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Resolvers
{
	[ExtendObjectType(typeof(ShoppingSession))]

	public class ShoppingSessionResolver
	{
		public ShoppingSessionResolver()
		{
		}
		
		public Task<ShoppingSession> GetShoppingSessionByCartAsync(
			  [Parent] CartItem cartItem,
			  [Service] IShoppingSessionRepository shoppingSessionRepository) => shoppingSessionRepository.GetByIdAsync(cartItem.SessionId);

	}
}

