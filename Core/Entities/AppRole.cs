using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Core.Entities
{
    [CollectionName("IdentityRoles")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {

    }

}

