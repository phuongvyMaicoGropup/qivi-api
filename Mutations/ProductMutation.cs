using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace qivi_api.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProductMutation
    {

        public async Task<Product> CreateProductAsync(string name, string description , decimal price ,int quantity , string categoryId ,
            int discountQuantity, int discountPercent,
           
            [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.InsertAsync(new Product(name, description, price, quantity, categoryId,discountPercent ,discountQuantity));

            await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveProductAsync(string id, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}

