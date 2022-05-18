using System;
using Core.Entities;
using Api.Resolvers;

namespace Api.Types
{
    public class BillType : ObjectType<Bill>
    {
        public BillType()
        {
        }
        protected override void Configure(IObjectTypeDescriptor<Bill> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.CustomerId);
            descriptor.Field(_ => _.Invoice);
            descriptor.Field(_ => _.IsSuccess);
            descriptor.Field(_ => _.Note);
            descriptor.Field(_ => _.LastUpdated);
            descriptor.Field(_ => _.Created);

            descriptor.Field<UserResolver>(_ => _.GetUserInfoAsync(default, default));
        }
    }
}

