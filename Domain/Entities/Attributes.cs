using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Attributes
    {
        [BsonElement("strength")]
        public int Strength { get; set; } = 0;
        [BsonElement("dexterity")]
        public int Dexterity { get; set; } = 0;
        [BsonElement("constitution")]
        public int Constitution { get; set; } = 0;
        [BsonElement("intelligence")]
        public int Intelligence { get; set; } = 0;
        [BsonElement("wisdom")]
        public int Wisdom { get; set; } = 0;
        [BsonElement("charisma")]
        public int Charisma { get; set; } = 0;
    }
}
