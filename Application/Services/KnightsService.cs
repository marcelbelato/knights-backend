using Application.Interfaces;
using Application.Mappers.Request;
using Domain.Entities;

namespace Application.Services
{
    public class KnightsService : IKnightsService
    {
        private readonly IKnightsRepository _knightsRepository;
        private bool disposedValue;

        public KnightsService(IKnightsRepository knightsRepository) =>
            _knightsRepository = knightsRepository ?? throw new ArgumentNullException(nameof(knightsRepository));

        public async Task Create(CreateKnightRequest request)
        {
            if (request.Weapons?.Where(w => w.Equipped).Count() > 1)
                throw new Exception("A knight can only have one weapon equipped");

            Knight knight = new()
            {
                Name = request.Name,
                Nickname = request.Nickname,
                Birthday = request.Birthday,
                Weapons = request.Weapons,
                Attributes = request.Attributes,
                KeyAttribute = request.KeyAttribute
            };

            await _knightsRepository.CreateAsync(knight);
        }

        public async Task<bool> Delete(string id) =>
            await _knightsRepository.DeleteAsync(id);

        public async Task<IEnumerable<Knight>> GetAll(string filter)
        {
            var knights = await _knightsRepository.GetAllAsync() ?? Enumerable.Empty<Knight>();

            return knights.Where(knight => string.Equals(knight.Class, filter, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Knight> GetById(string id) =>
            await _knightsRepository.GetByIdAsync(id);

        public async Task<bool> Update(string id, UpdateKnightRequest request)
        {
            var knight = await _knightsRepository.GetByIdAsync(id) ?? null;

            if (knight is null)
                return false;

            knight.Nickname = request.Nickname ?? string.Empty;

            return await _knightsRepository.UpdateAsync(knight);
        }

        public async Task<bool> TurnKnightIntoAHero(string id)
        {
            var knight = await _knightsRepository.GetByIdAsync(id) ?? null;

            if (knight is null)
                return false;

            knight.Class = "heroes";

            return await _knightsRepository.UpdateAsync(knight);
        }

        #region DisposeBlock

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        ~KnightsService()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
