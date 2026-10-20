using Core.Interfaces;
using Core.Services.Service.Types;

namespace Core.Services.Service.Dtos.Responses
{
    public class Response : IResponse, IJsonable
    {
        public string Message { get; set; } = string.Empty;
        public IEnumerable<EntityType?> Data { get; set; } = null;
        public int Count { get; set; } = 0;
        public bool Allowed { get; set; } = true;
    }
}
