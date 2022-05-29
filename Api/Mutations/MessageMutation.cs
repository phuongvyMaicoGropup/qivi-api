using System;
namespace Api.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class MessageMutation
	{
		private readonly ILogger<BillMutation> _logger;
		public MessageMutation(ILogger<BillMutation> logger)
		{
			_logger = logger; 
		}
	}
}

