using System;
using Core.Base;

namespace Core.Entities
{
	public class Message : BaseEntity
	{
		public Message(string creatorId , string messageBody , DateTime created, string receiverId)
		{
			Created = created;
			CreatorId = creatorId;
			MessageBody = messageBody;
			ReceiverId =  receiverId;
		}
		public string CreatorId { set; get; }
		public string MessageBody { set; get; }
		public DateTime Created { set; get; }
		public string ReceiverId { set; get; }

	}
}

