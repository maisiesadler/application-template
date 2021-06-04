using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Domain;
using Application.Minimal;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDomainLogic()
    .AddRepositories();

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/validate/{val}", async httpContext =>
    {
        var (ok, model) = Models.ParseValidationModel(httpContext.Request);
        if (!ok)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsync("Invalid Request");
            return;
        }

        var result = await endpoints.ServiceProvider.GetRequiredService<ValidationInteractor>().Execute(model);

        httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        await httpContext.Response.WriteAsync(result.ToString());
    });
});

await app.RunAsync();
