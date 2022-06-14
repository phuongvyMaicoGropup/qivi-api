using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;
using MongoDB.Driver;

namespace Api.Queries
{
	[ExtendObjectType(nameof(Query))]

	public class UserQuery
	{
		[UseFiltering]
		public async Task<IEnumerable<User>> GetUsers([Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
			var users =  await userRepository.GetAllAsync();
			await eventSender.SendAsync("ReturnedUsers", users);
			return users;  
		}

		public async Task<User> GetUserById(string userId,[Service]
		IUserRepository userRepository)
	=> await userRepository.GetByIdAsync(userId);


	}
}
