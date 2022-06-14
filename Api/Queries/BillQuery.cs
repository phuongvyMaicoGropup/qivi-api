using System;
using Api.Types.SortingsType;
using Core.Entities;
using Core.Repositories;

namespace Api.Queries
{
	[ExtendObjectType(nameof(Query))]
	public class BillQuery
	{
		[UseFiltering]
		public async Task<IEnumerable<Bill>> GetAllBillByCustomerAsync(string customerId, [Service] IBillRepository billRepository) =>
			await billRepository.GetAllBillByCustomerId(customerId);
		[UseFiltering]
		[UseSorting(typeof(BillSortingType))]
		public async Task<IEnumerable<Bill>> GetAllBill([Service] IBillRepository billRepository) =>
			await billRepository.GetAllAsync();
		public async Task<Bill> GetBillById(string id , [Service] IBillRepository billRepository) =>
			await billRepository.GetByIdAsync(id);
		[UseOffsetPaging]
		public async Task<IEnumerable<Bill>> GetBillsWithPagination([Service] IBillRepository billRepository) =>
			await billRepository.GetAllAsync();
	}
}