using Domain.Entities;

namespace Application.Mappers.Response
{
    public class GetKnightByIdResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public List<Weapon>? Weapons { get; set; }
        public Attributes Attributes { get; set; }
        public string KeyAttribute { get; set; }
    }
}
