using Domain.Entities;
using MongoDB.Driver;

namespace Application.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<Knight> Knights { get; }
    }
}
