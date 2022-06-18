using System;
using Core.Base;

namespace Core.Entities
{
	public class CartItem : BaseEntity
	{
		public CartItem()
        {

        }
		public CartItem(string productId , int quantity , string sessionId)
		{
			ProductId = productId;
			Quantity = quantity;
			SessionId = sessionId; 
		}
		public string SessionId { set; get; }
		public string ProductId { set; get; }
		public int Quantity { set; get; }
		public DateTime CreatedAt { set; get; } = DateTime.Now;
		public DateTime ModifiedAt { set; get; } = DateTime.Now; 


	}
}

