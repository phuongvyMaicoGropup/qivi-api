using System;
using Core.Base;

namespace Core.Entities
{
	public class Discount : BaseEntity
	{
		public Discount(string name, string description, int discountPercent, bool active , DateTime createdAt , DateTime modifiedAt)
		{
			Name = name;
			Description = description;
			DiscountPercent = discountPercent;
			Active = active;
			CreatedAt = createdAt;
			ModifiedAt = modifiedAt; 
		}
		public string Name { set; get;}
		public string Description { set; get; }
		public int DiscountPercent { set; get; }
		public bool Active { set; get; }
		public DateTime CreatedAt { set; get; }
		public DateTime ModifiedAt { set; get; }
	}
}

