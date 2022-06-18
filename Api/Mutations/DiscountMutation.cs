using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{

    [ExtendObjectType(nameof(Mutation))]



    public class DiscountMutation
    {
        private readonly ILogger<DiscountMutation> _logger;

        public DiscountMutation(ILogger<DiscountMutation> logger)
        {
            _logger = logger;
                        
        }
        public async Task<Discount> CreateDiscountAsync(string name, string description, int discountPercent, bool active, DateTime createdAt, DateTime modifiedAt,
            [Service] IDiscountRepository billRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await billRepository.InsertAsync(new Discount(name,description,discountPercent, active , createdAt , modifiedAt ));
            _logger.LogInformation("Create discount : [Detail] name: {name} , discountPercent : {discountPercent}", name, discountPercent );
            return result;
        }
        public Discount UpdateBillAsync(Discount discount,

            [Service] IDiscountRepository discountRepository, [Service] ITopicEventSender eventSender)
        {
            var result = discountRepository.Update(discount);
            _logger.LogInformation("Update discount {discountname} ", discount.Name);

            return result;
        }
        public async Task<bool> RemoveDiscountAsync(string id,

            [Service] IDiscountRepository discountRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await discountRepository.RemoveAsync(id);
            _logger.LogInformation("Remove discount {id}", id);
            return result;
        }
    }
}

