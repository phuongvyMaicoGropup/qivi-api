using System;
using Core.Base;
using Core.Entities;

namespace Core.Repositories
{
	public interface ICartItemRepository : IBaseRepository<CartItem>
	{
		public Task<List<CartItem>> GetBySessionId(string sessionId); 
	}
}

