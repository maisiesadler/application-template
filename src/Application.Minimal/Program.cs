using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Domain;
using Application.Minimal;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpoints()
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
        endpoints.ServiceProvider.GetRequiredService<ValidationEndpoint>().Execute(httpContext));
});

await app.RunAsync();
