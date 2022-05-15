using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly IMongoCollection<User> collection; 
		public UserRepository(ICatalogContext catalogContext) : base(catalogContext)
		{
			collection = catalogContext.GetCollection<User>("User"); 

		}
		public async Task<User> GetUserByPhoneNumber(string phoneNumber)
		=> await collection.Find(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync(); 
	}
}

