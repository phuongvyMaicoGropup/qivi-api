using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Base
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public void Update(object entity)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                //if (item.Name == "Id" || item.Name == "DomainEvents") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(entity).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(entity).ToString() == "0") continue;
                if (item.GetValue(entity) == null) continue;

                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(entity));
            }
        }
    }

}

