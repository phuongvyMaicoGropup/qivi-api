using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
    

	public class BillMutation
	{
        private readonly ILogger<BillMutation> _logger;

        public BillMutation(ILogger<BillMutation> logger)
		{
            _logger = logger; 

		}
        public async Task<Bill> CreateBillAsync(string customerId, decimal total, string note, string invoice, decimal amountOwed,

            [Service] IBillRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await billRepository.InsertAsync(new Bill(customerId, total , note, invoice, amountOwed));
            _logger.LogInformation("Create bill : [Detail] customerId: {customerId} total: {total} note:{note} invoice :{invoice} amountOwed : {amountOwed} ", customerId,total, note, invoice,amountOwed);
            return result;
        }
        public Bill UpdateBillAsync(Bill bill,

            [Service] IBillRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = billRepository.Update(bill);
            _logger.LogInformation("Update bill : [Detail] customerId: {customerId} total: {total} note:{note} invoice :{invoice} amountOwed : {amountOwed} ", bill.CustomerId,bill.Total, bill.Note, bill.Invoice,bill.AmountOwed);

            return result;
        }
        public async Task<bool> RemoveBillAsync(string id,

            [Service] IBillRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await billRepository.RemoveAsync(id);
            _logger.LogInformation("Remove bill {id}", id);
            return result;
        }
    }
}

