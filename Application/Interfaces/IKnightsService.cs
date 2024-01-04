using Application.Mappers.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IKnightsService : IDisposable
    {
        Task Create(CreateKnightRequest knight);
        Task<bool> Update(string id, UpdateKnightRequest knight);
        Task<bool> Delete(string id);
        Task<Knight> GetById(string id);
        Task<IEnumerable<Knight>> GetAll(string filter);
        Task<bool> TurnKnightIntoAHero(string id);
    }
}
