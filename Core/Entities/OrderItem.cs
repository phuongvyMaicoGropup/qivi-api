using System;
using Core.Base;

namespace Core.Entities
{
	public class OrderItem : BaseEntity
	{
		public OrderItem(string orderId, string productId, int quantity)
		{
			OrderId = orderId;
			ProductId = productId;
			Quantity = quantity;

		}
		public string OrderId { set; get; }
		public string ProductId { set; get; }
		public int Quantity { set; get; }
		public DateTime CreatedAt { set; get; } = DateTime.Now;
		public DateTime ModifiedAt { set; get; } = DateTime.Now; 
	}
}

