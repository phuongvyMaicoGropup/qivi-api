using System;
using System.Security.Claims;
using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Configurations
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        private IUserRepository _userRepository;
        public CustomUserIdProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //public string GetUserId(string userName)
        //{
        //    // your logic to fetch a user identifier goes here.

        //    // for example:

        //    var userId = _userRepository.GetByIdAsync(id);
        //    return userId.ToString();
        //}

        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(ClaimTypes.MobilePhone)?.Value!;
        }
    }
}

