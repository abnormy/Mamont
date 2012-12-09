using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public abstract class Entity
    {
        [BsonElement("_id")]
        public string Id { get; set; }
    }
}