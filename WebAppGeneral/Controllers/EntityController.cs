using Core.Extensions;
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
    public async Task<string> GetEntity([FromQuery] string entityId)
    {
        _logger.LogInformation("GetEntity called with entityId: {entityId}", entityId);
        var entity = await _serviceRepository.GetEntityAsync(entityId, default);
        return new Response()
        {
            Allowed = true,
            Message = $"Entity found: {entity.Name}",
            Count = entity != null ? 1 : 0
        }.ToJstring();
    }
    [HttpGet("GetAllEntities")]
    public async Task<string> GetAllEntities()
    {
        _logger.LogInformation("GetAllEntities called");
        var entities = await _serviceRepository.GetAllEntitiesAsync(default);
        return new Response()
        {
            Allowed = true,
            Message = $"Entities found: {entities.Count()}",
            Count = entities.Count()
        }.ToJstring();
    }
}
