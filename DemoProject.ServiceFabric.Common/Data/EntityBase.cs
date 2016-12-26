using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DemoProject.ServiceFabric.Common.Data
{
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}