using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Resolvers
{
	[ExtendObjectType(typeof(CartItemResolver))]

	public class CartItemResolver
	{
		public CartItemResolver()
		{
		}
        public Task<List<CartItem>> GetCartsFromSessionAsync(
         [Parent] ShoppingSession shoppingSession,
         [Service] ICartItemRepository cartItemRepository) => cartItemRepository.GetAllCartByUserId(shoppingSession.UserId);
	}
}

