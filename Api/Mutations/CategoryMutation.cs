using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
	[ExtendObjectType(Name ="Mutation")]
	public class CategoryMutation
	{
		public CategoryMutation()
		{
		}
        public async Task<Category> CreateCategoryAsync( string description, string categoryId , string parentCategory ,[Service] ICategoryRepository categoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await categoryRepository.InsertAsync(new Category( description, categoryId, parentCategory));

            await eventSender.SendAsync(nameof(Subscriptions.CategorySubscription.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveCategoryAsync(string id, [Service] ICategoryRepository categoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await categoryRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}

