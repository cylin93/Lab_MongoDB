using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lab_MongoDB_API.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("group")]
        public string Group { get; set; } = String.Empty;

        public string UserID { get; set; } = String.Empty;
    }
}
