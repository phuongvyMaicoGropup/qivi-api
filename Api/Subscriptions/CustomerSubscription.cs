using System;
using Core.Entities;
using Core.Repositories;

namespace Api.Subscriptions
{
	[ExtendObjectType(Name ="Subscription")]
	public class CustomerSubscription
	{
		[Subscribe]
		public User OnCreateCustomer([EventMessage] User user) => user;
	}
}

