using System;
using Api.Resolvers;
using Core.Entities;

namespace Api.Types
{
	public class OrderDetailsType : ObjectType<OrderDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderDetails> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.CreatedAt);
            descriptor.Field(_ => _.ModifiedAt);
            descriptor.Field(_ => _.Total);
            descriptor.Field(_ => _.UserId);
            descriptor.Field<UserResolver>(_ => _.GetUserByShoppingSessionAsync(default, default));
        }

    }
}

