using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Core.Entities
{
    [CollectionName("IdentityUsers")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
    }
}

