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
    public async Task<IActionResult> GetEntity([FromQuery] string entityId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetEntity called with entityId: {entityId}", entityId);
        var entity = await _serviceRepository.GetEntityAsync(entityId, cancellationToken);
        var response =  new Response()
        {
            Allowed = true,
            Message = $"Entity found: {entity?.Name ?? "Not found"}",
            Data = [entity],
            Count = entity != null ? 1 : 0
        };
        return entity is not null
            ? Ok(response)
            : NotFound(response);
    }
    [HttpGet("GetAllEntities")]
    public async Task<IActionResult> GetAllEntities(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetAllEntities called");
        var entities = await _serviceRepository.GetAllEntitiesAsync(cancellationToken);
        var response =  new Response()
        {
            Allowed = true,
            Message = $"Entities found: {entities.Count()}",
            Data = [.. entities],
            Count = entities.Count()
        };
        return entities.Any() 
            ? Ok(response) 
            : NotFound(response);
    }
}
