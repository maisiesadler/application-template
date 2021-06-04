using Microsoft.AspNetCore.Http;

namespace Application.Minimal
{
    public static class Models 
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
