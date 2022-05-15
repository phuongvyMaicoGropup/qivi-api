using System;
using Core.Base;

namespace Core.Entities
{
	public class Bill : BaseEntity
	{
		public Bill()
        {

        }
		public Bill(string customerId , decimal total , string note , string invoice )
		{
			CustomerId = customerId;
			Total = Total;
			Note = note;
			Invoice = invoice; 
		}
		public string CustomerId { set; get;} 
		public decimal Total { set; get; }
		public bool IsSuccess { set; get; } = false; 
		public decimal AmountOwed { set; get; } = 0; 
		public DateTime Created { set; get; } = DateTime.Now; 
		public DateTime LastUpdated { set; get; } = DateTime.Now;
		public string Note { set; get; } = "";
		public string Invoice { set; get; } = ""; 
	}
}

