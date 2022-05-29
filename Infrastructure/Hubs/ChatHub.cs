using System;
using Core.Entities;
using Core.Hubs;
using Core.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs
{
	public class ChatHub : Hub 
	{
        private IMessageRepository _messageRepository; 
		public ChatHub(IMessageRepository messageRepository)
		{
            _messageRepository = messageRepository; 
		}

        public Task ReceiveMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessage(string creatorId , string receiverId, string message)
        {
            var result = _messageRepository.InsertAsync(new Message(creatorId,message,DateTime.Now,receiverId));
            if (result != null)
            {
                var users = new string[] { creatorId, receiverId };
                await Clients.Users(users).SendAsync("SendMessage", message);

            }
            await Clients.All.SendAsync("SendMessage", message);

        }
    }
}

