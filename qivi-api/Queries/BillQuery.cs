using System;
using Core.Entities;
using Core.Repositories;

namespace qivi_api.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class BillQuery
	{
		public async Task<IEnumerable<Bill>> GetAllBillByCustomerAsync(string customerId, [Service] IBillRepository billRepository) =>
			await billRepository.GetAllBillByCustomerId(customerId);
		public async Task<IEnumerable<Bill>> GetAllBill([Service] IBillRepository billRepository) =>
			await billRepository.GetAllAsync();
		public async Task<Bill> GetBillById(string id , [Service] IBillRepository billRepository) =>
			await billRepository.GetByIdAsync(id);

	}
}

