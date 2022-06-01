using System;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class MessageRepository : BaseRepository<Message>,IMessageRepository
    {
        //public MessageRepository(IHubConnectionContext<dynamic> clients)
        //{

        //}

        private readonly IMongoCollection<Message> collection;
        public MessageRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
            if (catalogContext == null)
            {
                throw new ArgumentNullException(nameof(catalogContext));
            }

            collection = catalogContext.GetCollection<Message>("Message");
        }
    }
}

