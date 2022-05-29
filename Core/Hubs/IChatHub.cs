using System;
using Core.Entities;
using Microsoft.AspNetCore.SignalR;
namespace Core.Hubs
{
    public interface IChatHub 
    {
        public Task SendMessage(Message message);
        public Task ReceiveMessage(Message message);
    }
}

