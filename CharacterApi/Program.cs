using CharacterApi.Endpoints;
using CharacterApi.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

DependencyInjection.RegisterContainers(builder.Services);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapCharacterEndpoints();

app.Run();
