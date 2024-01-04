﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Knight
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement("name")]
        public required string Name { get; set; }
        [BsonElement("nickname")]
        public required string Nickname { get; set; }
        [BsonElement("birthday")]
        public required DateTime Birthday { get; set; }
        [BsonElement("weapons")]
        public List<Weapon>? Weapons { get; set; }
        [BsonElement("attributes")]
        public Attributes? Attributes { get; set; }
        [BsonElement("keyAttribute")]
        public required string KeyAttribute { get; set; }
        public string Class { get; set; } = "knights";

        private int _attack;
        private int _age;
        private double _experience;

        public int Attack
        {
            get => _attack;
            private set => _attack = CalculateAttack();
        }

        public int Age
        {
            get => _age;
            private set => _age = CalculateAge();
        }

        public double Experience
        {
            get => _experience;
            private set => _experience = CalculateExperience();
        }

        public int CountWeapons => Weapons?.Count ?? 0;

        private int CalculateAttack()
        {
            var attackValue = 10;

            var modWeaponValue = Weapons?.Where(w => w.Equipped).FirstOrDefault()?.Mod ?? 0;
            attackValue += modWeaponValue;

            var keyAttrValue = Attributes?.GetType().GetProperty(KeyAttribute)?.GetValue(Attributes, null) ?? 0;
            var modKeyAttribute = GetKeyAttributeModifier((int)keyAttrValue);
            attackValue += modKeyAttribute;

            return attackValue;
        }

        private int CalculateAge()
        {
            var zeroTime = new DateTime(1, 1, 1);
            var today = DateTime.Now;
            var span = today - Birthday;
            var years = (zeroTime + span).Year - 1;
            return years;
        }

        private double CalculateExperience() =>
            Math.Floor((_age - 7) * Math.Pow(22, 1.45));

        private int GetKeyAttributeModifier(int keyAttrValue) =>
            keyAttrValue switch
            {
                9 or 10 => -1,
                11 or 12 => 0,
                >= 13 and <= 15 => 1,
                >= 16 and <= 18 => 2,
                19 or 20 => 3,
                _ => -2
            };
    }
}