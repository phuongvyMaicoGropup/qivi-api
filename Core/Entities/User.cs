using System;
using Core.Base;

namespace Core.Entities
{
	public class User : BaseEntity
	{
		public User()
        {

        }
		public User(string name,string fullName,string phoneNumber, string address)
		{
			UserName = name;
			FullName = fullName; 
			PhoneNumber = phoneNumber;
			Address = address; 
		}
		public string UserName { set; get; }
		public string FullName { set; get; }
		public string PhoneNumber { set; get; }
		public string Address { set; get; }

		
	}
}

