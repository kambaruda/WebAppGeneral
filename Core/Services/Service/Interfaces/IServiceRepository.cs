using Microsoft.Extensions.Logging;

namespace Core.Services.Service.Interfaces
{
    public interface IServiceRepository
    {
        public Task<object> GetEntityAsync(string entityId, CancellationToken cancellationToken);
        public object GetEntity(string entityId);
        public Task<IEnumerable<object>> GetEntitiesAsync(string entityCriteria, CancellationToken cancellationToken);
        public IEnumerable<object> GetEntities(string entityCriteria);
        public Task<object> CreateEntityAsync(object entity, CancellationToken cancellationToken);
        public object CreateEntity(object entity);
        public Task<object> CreateEntitiesAsync(IEnumerable<object> entities, CancellationToken cancellationToken);
        public IEnumerable<object> CreateEntities(IEnumerable<object> entities);
        public Task<object> UpdateEntityAsync(string entityId, object entity, CancellationToken cancellationToken);
        public object UpdateEntity(string entityId, object entity);
        public Task<object> UpdateEntitiesAsync(string entityCriteria, IEnumerable<object> entities, CancellationToken cancellationToken);
        public object UpdateEntities(string entityCriteria, IEnumerable<object> entities);
    }
}
