using System;
using Core.Entities;
using qivi_api.Resolvers;

namespace qivi_api.Types
{
	public class CategoryType : ObjectType<Category>
	{
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.ParentCategory);
            descriptor.Field(_ => _.Description);
            descriptor.Field(_ => _.CategoryId);

            descriptor.Field<CategoryResolver>(_ => _.GetParentCategoryAsync(default, default));
        }
    }
}

