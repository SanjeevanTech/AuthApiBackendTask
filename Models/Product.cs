using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string?Id { get; set; } 

        [BsonElement("productname")]
        public string Productname { get; set; } = string.Empty;

        [BsonElement("price")]
        public string Price { get; set; } = string.Empty;

        [BsonElement("productDescription")]
        public string ProductDescription { get; set; } = string.Empty;

    }
}
