using Clicksign.Exemplo.Config;
using Clicksign.Exemplo.Repositories;
using Clicksign.Exemplo.UseCases.CreateAcceptanceTermUseCase;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Clicksign Config
var clickSignConfig = new ClickSignConfig();
builder.Configuration.Bind("ClickSign", clickSignConfig);
builder.Services.AddSingleton(clickSignConfig);

builder.Services.AddHttpClient<IClickSignRepository, ClickSignRepository>();

builder.Services.AddScoped<ICreateAcceptanceTermUseCase, CreateAcceptanceTermUseCase>();

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
