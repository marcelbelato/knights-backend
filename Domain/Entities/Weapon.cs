using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Weapon
    {
        [BsonElement("name")]
        public string Name { get; set; } = "";
        [BsonElement("mod")]
        public int Mod { get; set; } = 0;
        [BsonElement("attr")]
        public string Attr { get; set; } = "";
        [BsonElement("equipped")]
        public bool Equipped { get; set; } = false;
    }
}
