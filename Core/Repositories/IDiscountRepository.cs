

using System;
using Core.Base;
using Core.Entities;

namespace Core.Repositories
{
	public interface IDiscountRepository : IBaseRepository<Discount>
	{
		public Task<IEnumerable<Discount>> GetActiveDiscounts(); 
	}


}

