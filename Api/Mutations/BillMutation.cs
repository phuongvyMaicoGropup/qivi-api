using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
	[ExtendObjectType(Name = "Mutation")]

	public class BillMutation
	{
		public BillMutation()
		{
		}
        public async Task<Bill> CreateBillAsync(string customerId, decimal total, string note, string invoice,

            [Service] IBillRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await billRepository.InsertAsync(new Bill(customerId, total , note, invoice));

            return result;
        }
        public Bill UpdateBillAsync(Bill bill,

            [Service] IBillRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = billRepository.Update(bill);

            return result;
        }
        public async Task<bool> RemoveBillAsync(string id,

            [Service] IBillRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await billRepository.RemoveAsync(id);

            return result;
        }
    }
}

