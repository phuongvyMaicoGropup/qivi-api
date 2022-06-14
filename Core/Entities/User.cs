using System;
using Core.Base;

namespace Core.Entities
{
	public class User : BaseEntity
	{
		public User(string name, string phoneNumber, string address)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			Address = address; 
		}
		public string Name { set; get; }
		public string PhoneNumber { set; get; }
		public string Address { set; get; }

		
	}
}

