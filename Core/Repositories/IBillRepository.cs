using System;
using Core.Base;
using Core.Entities;

namespace Core.Repositories
{
	public interface IBillRepository : IBaseRepository<Bill>
	{
		public Task<List<Bill>> GetAllBillByCustomerId(string customerId);
		public Task<List<Bill>> GetAllOwnsBill();
		public Task<List<Bill>> GetAllNotSuccessBill();

	}
}

