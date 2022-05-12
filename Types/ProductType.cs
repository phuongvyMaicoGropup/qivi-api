using System;
using Core.Entities;
using HotChocolate.Types;
using qivi_api.Resolvers;

namespace qivi_api.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.CategoryId);
            descriptor.Field(_ => _.Name);
            descriptor.Field(_ => _.Description);
            descriptor.Field(_ => _.Price);
            descriptor.Field(_ => _.DiscountPercent);
            descriptor.Field(_ => _.DiscountQuantity);
            descriptor.Field(_ => _.UnitsInStock);

            // Creates the relationship between Product x Category
            descriptor.Field<CategoryResolver>(_ => _.GetCategoryAsync(default, default));
        }
    }
}

