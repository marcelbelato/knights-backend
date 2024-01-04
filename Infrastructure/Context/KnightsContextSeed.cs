using Domain.Entities;
using MongoDB.Driver;

namespace Infrastructure.Context
{
    public class KnightsContextSeed
    {
        public static void SeedData(IMongoCollection<Knight> mongoCollection)
        {
            bool existKnight = mongoCollection.Find(p => true).Any();

            if (!existKnight)
                mongoCollection.InsertManyAsync(GetPreconfiguredKnights());
        }

        private static IEnumerable<Knight> GetPreconfiguredKnights()
        {
            return new List<Knight>()
            {
                new Knight
                {
                    Name = "Arthur",
                    Nickname = "King Arthur",
                    Birthday = new DateTime(2017, 1, 1),
                    Weapons = new List<Weapon> {
                        new Weapon { Name = "Sword", Mod = 3, Attr = "Strength", Equipped = true }
                    },
                    Attributes = new Attributes
                    {
                        Strength = 12,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charisma = 10
                    },
                    KeyAttribute = "Strength"
                },
                new Knight
                {
                    Name = "Lancelot",
                    Nickname = "Sir Lancelot",
                    Birthday = new DateTime(2000, 1, 1),
                    Weapons = new List<Weapon> {
                        new Weapon { Name = "Arrow", Mod = 6, Attr = "Dexterity", Equipped = true },
                        new Weapon { Name = "Shield", Mod = 3, Attr = "Wisdom", Equipped = false }
                    },
                    Attributes = new Attributes
                    {
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 17,
                        Wisdom = 10,
                        Charisma = 10
                    },
                    KeyAttribute = "Intelligence"
                }
            };
        }
    }
}
