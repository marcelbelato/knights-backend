using Domain.Entities;

namespace Application.Mappers.Response
{
    public class GetAllKnightsResponse
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? Nickname { get; set; }
        public required DateTime Birthday { get; set; }
        public List<Weapon>? Weapons { get; set; }
        public required Attributes Attributes { get; set; }
        public required string KeyAttribute { get; set; }
        public required string Class { get; set; }
        public int Attack { get; set; }
        public int Age { get; set; }
        public double Experience { get; set; }
        public int CountWeapons { get; set; }
    }
}
