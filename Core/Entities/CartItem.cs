using System;
using Core.Base;

namespace Core.Entities
{
	public class CartItem : BaseEntity
	{
		public CartItem(string productId , string userId, int quantity)
		{
			ProductId = productId;
			UserId = userId;
			Quantity = quantity; 
		}
		public string ProductId { set; get; }
		public string UserId { set; get; }
		public int Quantity { set; get; }


	}
}

