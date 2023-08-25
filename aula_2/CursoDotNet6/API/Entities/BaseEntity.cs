using API.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool Deleted { get; set; }
        public string Slug { get; set; }

        [BsonElement("publishDate")]
        public DateTime PublishDate { get; set; }

        [BsonElement("active")]
        public Status Status { get; protected set; }
    }
}
