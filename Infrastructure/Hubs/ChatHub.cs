using System;
using Core.Entities;
using Core.Hubs;
using Core.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs
{
	public class ChatHub : Hub , IChatHub
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

        public async Task SendMessage(Message message)
        {
            var result = _messageRepository.InsertAsync(message);
            if (result != null)
            {
                var users = new string[] { message.CreatorId, message.ReceiverId };
                await Clients.Users(users).SendAsync("SendMessage", message);

            }
            await Clients.All.SendAsync("SendMessage", message);

        }
    }
}

