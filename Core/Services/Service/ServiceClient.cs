using Core.Services.Service.Interfaces;
using Core.Services.Service.Types;
using Microsoft.Extensions.Logging;

namespace Core.Services.Service
{
    public class ServiceClient(ServiceOptions options, ILogger<IServiceRepository> logger) : IServiceRepository
    {
        private readonly ServiceOptions _options = options;
        private ILogger<IServiceRepository> _logger = logger;

        public Task<IEnumerable<EntityType>> GetAllEntitiesAsync(CancellationToken cancellationToken)
        {
            var entities = new List<EntityType>
            {
                new() { Id = "1", Name = "Entity 1", Description = "Description for entity 1" },
                new() { Id = "2", Name = "Entity 2", Description = "Description for entity 2" },
                new() { Id = "3", Name = "Entity 3", Description = "Description for entity 3" }
            };
            return Task.FromResult<IEnumerable<EntityType>>(entities);
        }

        public Task<EntityType> GetEntityAsync(string entityId, CancellationToken cancellationToken)
        {
            return Task.FromResult(new EntityType
            {
                Id = entityId,
                Name = $"Entity {entityId}",
                Description = $"Description for entity {entityId}"
            });
        }
    }
}
