using System;
using Core.Base;

namespace Core.Entities
{
	public class Category : BaseEntity
	{
		public Category() {
		}
		public Category(string description, string categoryId, string parentCategory)
        {
			CategoryId = categoryId; 
			Description = description;
			ParentCategory = parentCategory; 
        }
		public string CategoryId { set; get; }
		public string Description { get; set; }
		public string ParentCategory { set; get; }
		
	}
}

