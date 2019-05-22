using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CellPhonesAPI.Models
{
    public class CellPhone
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("marca")]
        public string Marca { get; set; }

        [BsonElement("modelo")]
        public string Modelo { get; set; }

        [BsonElement("os")]
        public string OS { get; set; }

        [BsonElement("preco")]
        public decimal Preco { get; set; }
    }
}
