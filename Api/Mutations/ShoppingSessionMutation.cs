using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class ShoppingSessionMutation
	{
		public ShoppingSessionMutation()
		{
		}
        public async Task<ShoppingSession> CreateShoppingSessionAsync(string userId,decimal total,

            [Service] IShoppingSessionRepository shoppingSessionRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await shoppingSessionRepository.InsertAsync(new ShoppingSession(userId, total));

            return result;
        }
        public ShoppingSession UpdateCartItemAsync(ShoppingSession shoppingSession,

            [Service] IShoppingSessionRepository shoppingSessionRepository, [Service] ITopicEventSender eventSender)
        {
            var result = shoppingSessionRepository.Update(shoppingSession);

            return result;
        }
        public async Task<bool> RemoveCartItemAsync(string id,

            [Service] IShoppingSessionRepository shoppingSessionRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await shoppingSessionRepository.RemoveAsync(id);

            return result;
        }
    }

}

