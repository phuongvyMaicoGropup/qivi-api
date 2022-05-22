using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Api.Subscriptions
{
	[ExtendObjectType(Name ="Subscription")]
	public class CustomerSubscription
	{
		[Subscribe]
		public User OnCreateCustomer([EventMessage] User user) => user;
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream
        <List<User>>> OnUsersGet([Service]
        ITopicEventReceiver eventReceiver,
           CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string,
            List<User>>("ReturnedUsers",
            cancellationToken);
        }
    }
}

