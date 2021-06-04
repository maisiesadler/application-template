using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Minimal.Endpoints
{
    public interface IEndpoint
    {
        Task Execute(HttpContext httpContext);
    }
}
