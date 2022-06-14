using System;
using Core.Entities;
using Core.Hubs;
using Core.Repositories;
using Infrastructure.Configurations;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageRepository _messageRepository;
        //private readonly static ConnectionMapping<string> _connections =
        //    new ConnectionMapping<string>();
        public ChatHub(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository; 
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }


        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;


            //_connections.Add(name, Context.ConnectionId);

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

