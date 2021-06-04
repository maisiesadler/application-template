using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Application.Domain;

namespace Application.Minimal
{
    public class ValidationEndpoint
    {
        private readonly ValidationInteractor _validationInteractor;

        public ValidationEndpoint(ValidationInteractor validationInteractor)
        {
            _validationInteractor = validationInteractor;
        }

        public async Task Execute(HttpContext httpContext)
        {
            var (ok, model) = Models.ParseValidationModel(httpContext.Request);
            if (!ok)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsync("Invalid Request");
                return;
            }

            var result = await _validationInteractor.Execute(model);

            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            await httpContext.Response.WriteAsync(result.ToString());
        }
    }
}
