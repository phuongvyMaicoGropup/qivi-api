using System;
using Core.Entities;
using Api.Resolvers;

namespace Api.Types
{
	public class CartItemType : ObjectType<CartItem>
	{
		public CartItemType()
		{
		}
        protected override void Configure(IObjectTypeDescriptor<CartItem> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.UserId);
            descriptor.Field(_ => _.ProductId);
            descriptor.Field(_ => _.Quantity);

            descriptor.Field<ProductResolver>(_ => _.GetProductInCartAsync(default, default));
        }
    }
}

