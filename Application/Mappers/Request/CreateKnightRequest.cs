using Domain.Entities;

namespace Application.Mappers.Request
{
    public sealed class CreateKnightRequest
    {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public required DateTime Birthday { get; set; }
        public List<Weapon>? Weapons { get; set; }
        public Attributes? Attributes { get; set; }
        public required string KeyAttribute { get; set; }
    }
}
