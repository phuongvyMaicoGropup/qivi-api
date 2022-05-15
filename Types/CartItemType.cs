using System;
using Core.Entities;
using qivi_api.Resolvers;

namespace qivi_api.Types
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

