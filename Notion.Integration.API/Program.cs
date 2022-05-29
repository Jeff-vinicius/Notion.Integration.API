using MediatR;
using Notion.Integration.Domain.Commands;
using Notion.Integration.Domain.Interfaces;
using Notion.Integration.Infrastructure.Services;
using Notion.Integration.Infrastructure.Repositories;
using Notion.Integration.Infrastructure.Integrations.NotionAPI;
using Notion.Integration.Infrastructure.Integrations.FakeAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Dependency Injection
builder.Services.AddScoped<IFakeAPIService, FakeAPIService>();
builder.Services.AddScoped<INotionAPIService, NotionAPIService>();
builder.Services.AddScoped<IIntegrationNotionRepository, IntegrationNotionRepository>();
builder.Services.AddScoped<INotionAPI, NotionAPI>();
builder.Services.AddScoped<IFakeAPI, FakeAPI>();

builder.Services.AddScoped<IRequestHandler<CreateIntegrationCommand, IntegrationResponse>, IntegrationCommandHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
