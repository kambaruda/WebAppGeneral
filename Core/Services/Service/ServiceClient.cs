using Core.Services.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Services.Service
{
    public class ServiceClient(ServiceOptions options, ILogger<IServiceRepository> logger) : IServiceRepository
    {
        private readonly ServiceOptions _options = options;
        private ILogger<IServiceRepository> _logger = logger;

        public IEnumerable<object> CreateEntities(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public Task<object> CreateEntitiesAsync(IEnumerable<object> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public object CreateEntity(object entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> CreateEntityAsync(object entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetEntities(string entityCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<object>> GetEntitiesAsync(string entityCriteria, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public object GetEntity(string entityName, string entityId)
        {
            throw new NotImplementedException();
        }

        public object GetEntity(string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetEntityAsync(string entityName, string entityId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetEntityAsync(string entityId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public object UpdateEntities(string entityCriteria, IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateEntitiesAsync(string entityCriteria, IEnumerable<object> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public object UpdateEntity(string entityId, object entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateEntityAsync(string entityId, object entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
