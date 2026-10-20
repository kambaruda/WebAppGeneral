using Core.Services.Service.Dtos.Requests;
using Core.Services.Service.Dtos.Responses;
using Core.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAppGeneral.Controllers;

[ApiController]
[Route("[controller]")]
public class EntityController(ILogger<EntityController> logger, IServiceRepository serviceRepository) : ControllerBase
{
    private readonly ILogger<EntityController> _logger = logger;
    private readonly IServiceRepository _serviceRepository = serviceRepository;
    [HttpPost("PostHelloWorld")]
    public Response PostHelloWorld([FromBody] Request request)
    {
        var response = new Response
        {
            Message = $"Hello, {request.Message}!"
        };
        return response;
    }
    [HttpGet("GetEntity")]
    public async Task<object> GetEntity([FromQuery] string entityId)
    {
        _logger.LogInformation("GetEntity called with entityId: {entityId}", entityId);
        var entity = await _serviceRepository.GetEntityAsync(entityId, default);
        return entity;
    }
    [HttpGet("GetEntities")]
    public async Task<IEnumerable<object>> GetEntities([FromQuery] string entityCriteria)
    {
        _logger.LogInformation("GetEntities called with entityCriteria: {entityCriteria}", entityCriteria);
        var entities = await _serviceRepository.GetEntitiesAsync(entityCriteria, default);
        return entities;
    }
    [HttpPost("CreateEntity")]
    public async Task<object> CreateEntity([FromBody] object entity)
    {
        _logger.LogInformation("CreateEntity called with entity: {entity}", entity);
        var createdEntity = await _serviceRepository.CreateEntityAsync(entity, default);
        return createdEntity;
    }
    [HttpPatch("UpdateEntity")]
    public async Task<object> UpdateEntity([FromQuery] string entityId, [FromBody] object entity)
    {
        _logger.LogInformation("UpdateEntity called with entityId: {entityId} and entity: {entity}", entityId, entity);
        var updatedEntity = await _serviceRepository.UpdateEntityAsync(entityId, entity, default);
        return updatedEntity;
    }
    [HttpPut("UpsertEntity")]
    public async Task<object> UpsertEntity([FromQuery] string entityId, [FromBody] object entity)
    {
        _logger.LogInformation("UpsertEntity called with entityId: {entityId} and entity: {entity}", entityId, entity);
        var existingEntity = await _serviceRepository.GetEntityAsync(entityId, default);
        if (existingEntity != null)
        {
            var updatedEntity = await _serviceRepository.UpdateEntityAsync(entityId, entity, default);
            return updatedEntity;
        }
        else
        {
            var createdEntity = await _serviceRepository.CreateEntityAsync(entity, default);
            return createdEntity;
        }
    }
}
