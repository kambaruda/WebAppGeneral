using Core.Interfaces;

namespace Core.Services.Service.Dtos.Responses
{
    public class Response : IResponse, IJsonable
    {
        public string Message { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
        public bool Allowed { get; set; } = true;
    }
}
