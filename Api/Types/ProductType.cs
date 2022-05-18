using System;
using Core.Entities;
using HotChocolate.Types;
using Api.Resolvers;

namespace Api.Types
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
            descriptor.Field(_ => _.DiscountPrice);
            descriptor.Field(_ => _.DiscountQuantity);
            descriptor.Field(_ => _.IsEmpty);
            descriptor.Field(_ => _.Quantity);
            descriptor.Field(_ => _.Image);


            // Creates the relationship between Product x Category
            descriptor.Field<CategoryResolver>(_ => _.GetCategoryAsync(default, default));
        }
    }
}

