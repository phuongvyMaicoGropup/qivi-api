using System;
using Core.Entities;

namespace Api.Subscriptions
{
    [ExtendObjectType("Subscription")]
	public class CategorySubscription
	{
		public CategorySubscription()
		{
		}

        [Subscribe]
        [Topic]
        public Task<Category> OnCreateAsync([EventMessage] Category category) =>
            Task.FromResult(category);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string categoryId) =>
            Task.FromResult(categoryId);
    }
}

