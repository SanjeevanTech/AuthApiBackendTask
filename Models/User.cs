using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string?Id { get; set; }  

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("firstname")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("lastname")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
    }
}
