using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
    [ExtendObjectType(nameof(Mutation))]
	public class OrderDetailsMutation
	{
		public OrderDetailsMutation()
		{
		}
        public async Task<OrderDetails> CreateOrderDetailsAsync(string userId, 

            [Service] IOrderDetailsRepository orderDetailsRepository, [Service] ITopicEventSender eventSender)
        {
            var order = await orderDetailsRepository.GetByUserId(userId);
            if (order == null)
            {
                var result = await orderDetailsRepository.InsertAsync(new OrderDetails(userId));
                return result;
            }
            return null; 
            

        }
        public async Task<OrderDetails> UpdateOrderDetailsAsync(OrderDetails order,

            [Service] IOrderDetailsRepository orderDetailsRepository, [Service] ITopicEventSender eventSender)
        {
            var orderInDB = await orderDetailsRepository.GetByIdAsync(order.Id);
            if (orderInDB != null)
            {
                return orderDetailsRepository.Update(order);

            }
            return null; 

        }
        public async Task<bool> RemoveCartItemAsync(string id,

            [Service] IShoppingSessionRepository shoppingSessionRepository, [Service] ITopicEventSender eventSender)
        => await shoppingSessionRepository.RemoveAsync(id);
        
    }
}

