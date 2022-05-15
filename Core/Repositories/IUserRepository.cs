using System;
using Core.Base;
using Core.Entities;

namespace Core.Repositories
{
	public interface IUserRepository : IBaseRepository<User>
	{

		public Task<User> GetUserByPhoneNumber(string phoneNumber); 
	}
}

