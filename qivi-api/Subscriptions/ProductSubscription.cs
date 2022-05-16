using System;
using Core.Entities;

namespace qivi_api.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class ProductSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Product> OnCreateAsync([EventMessage] Product product) =>
            Task.FromResult(product);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string productId) =>
            Task.FromResult(productId);
    }
}

