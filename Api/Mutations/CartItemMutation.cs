﻿using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
	[ExtendObjectType(Name = "Mutation")]

	public class CartItemMutation
	{
		public CartItemMutation()
		{
		}
        public async Task<CartItem> CreateCartItemAsync(string productId, string userId, int quantity, string sessionId,

            [Service] ICartItemRepository cartItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await cartItemRepository.InsertAsync(new CartItem(productId, userId, quantity, sessionId));

            return result;
        }
        public CartItem UpdateCartItemAsync(CartItem cartItem,

            [Service] ICartItemRepository cartItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result =  cartItemRepository.Update(cartItem);

            return result;
        }
        public async Task<bool> RemoveCartItemAsync(string id,

            [Service] ICartItemRepository cartItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await cartItemRepository.RemoveAsync(id);

            return result;
        }
    }
}

