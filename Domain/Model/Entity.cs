using MongoDB.Bson;

namespace Domain
{
    public abstract class Entity
    {
        public ObjectId Id { get; set; }
    }
}