using System;
using Core.Entities;
using Core.Hubs;
using Core.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageRepository _messageRepository;
        public ChatHub(IMessageRepository messageRepository)
        {
            if (messageRepository == null)
            {
                throw new ArgumentNullException("messageRepository");
            }
            _messageRepository = messageRepository; 
        }

        public override Task OnConnectedAsync()
        {
            if (string.IsNullOrEmpty(Context.ConnectionId))
            {
                throw new System.Exception(nameof(Context.ConnectionId)); //This code is never hit
            }
            Clients.All.SendAsync("broadcastMessage", "system", $"{Context.ConnectionId} joined the conversation");
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string creatorId, string receiverId, string message)
        {
            var result = _messageRepository.InsertAsync(new Message(creatorId, message, DateTime.Now, receiverId));
            if (result != null)
            {
                var users = new string[] { creatorId, receiverId };
                await Clients.Users(users).SendAsync("SendMessage", message);

            }
            await Clients.All.SendAsync("ReceiveMessage", creatorId, receiverId, message);

        }
    }
}

