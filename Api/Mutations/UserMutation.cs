using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
    [ExtendObjectType(Name ="Mutation")]
	public class UserMutation
	{
		public UserMutation()
		{
		}

        public async Task<User> CreateUserAsync(string name, string phoneNumber, string address, 
            [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await userRepository.InsertAsync(new User(name,phoneNumber, address));

            //await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);

            return result;
        }

        public User UpdateUser(User user,  [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result =  userRepository.Update(user);

            if (result != null)
            {
                //await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
        public async Task<bool> RemoveUserAsync(string id, [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await userRepository.RemoveAsync(id);

            if (result)
            {
                //await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
        public async Task<User> GetUserByIdAsync(string id, [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await userRepository.GetByIdAsync(id);

            return result;
        }
        public async Task<User> GetUserByPhoneAsync(string phoneNumber, [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await userRepository.GetUserByPhoneNumber(phoneNumber);

            return result;
        }
    }
}

