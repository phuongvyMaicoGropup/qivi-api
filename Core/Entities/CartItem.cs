using System;
using Core.Base;

namespace Core.Entities
{
	public class CartItem : BaseEntity
	{
		public CartItem()
        {

        }
		public CartItem(string productId , string userId, int quantity , string sessionId)
		{
			ProductId = productId;
			UserId = userId;
			Quantity = quantity;
			SessionId = sessionId; 
		}
		public string SessionId { set; get; }
		public string ProductId { set; get; }
		public string UserId { set; get; }
		public int Quantity { set; get; }


	}
}

