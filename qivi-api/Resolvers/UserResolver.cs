using System;
using Core.Entities;
using Core.Repositories;

namespace qivi_api.Resolvers
{
	[ExtendObjectType(Name = "Customer")]

	public class UserResolver
	{
		public UserResolver()
		{
		}
		public Task<User> GetUserInfoAsync(
			  [Parent] Bill bill,
			  [Service] IUserRepository userRepository) => userRepository.GetByIdAsync(bill.CustomerId);


	}
}

