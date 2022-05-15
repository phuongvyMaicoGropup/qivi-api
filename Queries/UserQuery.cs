using System;
using Core.Entities;
using Core.Repositories;
using MongoDB.Driver;

namespace qivi_api.Queries
{
	[ExtendObjectType(Name = "Query")]

	public class UserQuery
	{
		[UseFiltering]
		public async Task<IEnumerable<User>> GetUsers([Service] IUserRepository userRepository)
	=> await userRepository.GetAllAsync(); 
		public async Task<User> GetUserById(string userId,[Service]
		IUserRepository userRepository)
	=> await userRepository.GetByIdAsync(userId);


	}
}
