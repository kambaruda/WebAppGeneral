using Core.Interfaces;

namespace Core.Services.Service.Dtos.Requests
{
    public class Request : IRequest, IJsonable
    {
        public string Message { get; set; } = string.Empty;
    }
}
