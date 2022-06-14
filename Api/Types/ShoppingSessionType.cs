using System;
using Core.Entities;
using Api.Resolvers;

namespace Api.Types
{
    public class ShoppingSessionType : ObjectType<ShoppingSession>
    {
        protected override void Configure(IObjectTypeDescriptor<ShoppingSession> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.UserId);
            descriptor.Field(_ => _.Total);

            descriptor.Field<UserResolver>(_ => _.GetUserByShoppingSessionAsync(default, default));
        }
    }
}

