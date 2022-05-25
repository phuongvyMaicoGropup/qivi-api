using System;
using Core.Entities;
using HotChocolate.Data.Sorting;

namespace Api.Types.SortingsType
{
	public class BillSortingType : SortInputType<Bill>
	{
        protected override void Configure(ISortInputTypeDescriptor<Bill> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Created).Name("created");
        }
    }
    public class AscOnlySortEnumType : DefaultSortEnumType
    {
        protected override void Configure(ISortEnumTypeDescriptor descriptor)
        {
            descriptor.Operation(DefaultSortOperations.Ascending);
        }
    }

}

