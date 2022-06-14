using System;
using Core.Entities;

namespace Api.Types
{
	public class DiscountType : ObjectType<Discount>
	{
        protected override void Configure(IObjectTypeDescriptor<Discount> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.CreatedAt);
            descriptor.Field(_ => _.ModifiedAt);
            descriptor.Field(_ => _.Name);
            descriptor.Field(_ => _.DiscountPercent);
            descriptor.Field(_ => _.Active);
        }

    }
}

