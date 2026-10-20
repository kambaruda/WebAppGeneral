using Core.Services.Service.Types;
using Microsoft.Extensions.Logging;

namespace Core.Services.Service.Interfaces
{
    public interface IServiceRepository
    {
        public Task<EntityType> GetEntityAsync(string entityId, CancellationToken cancellationToken);
        public Task<IEnumerable<EntityType>> GetAllEntitiesAsync(CancellationToken cancellationToken);

    }
}
