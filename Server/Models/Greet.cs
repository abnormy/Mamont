using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class Greet
    {
        public ObjectId Id { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
    }
}