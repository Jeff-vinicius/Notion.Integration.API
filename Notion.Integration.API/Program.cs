using Notion.Integration.API.Services;
using Notion.Integration.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Dependency Injection
builder.Services.AddScoped<IIntegrationService, IntegrationService>();
builder.Services.AddScoped<IFakeAPIService, FakeAPIService>();
builder.Services.AddScoped<INotionAPIService, NotionAPIService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
