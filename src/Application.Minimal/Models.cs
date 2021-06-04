using Microsoft.AspNetCore.Http;

namespace Application.Minimal.Models
{
    public class RequestParsing
    {
        public static (bool, int) ParseValidationModel(HttpRequest request)
        {
            if (request.RouteValues.TryGetValue("val", out var val)
                && int.TryParse(val.ToString(), out var i))
                return (true, i);

            return (false, -1);
        }
    }
}
