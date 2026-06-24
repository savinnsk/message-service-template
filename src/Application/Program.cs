using message_service.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraServices(builder.Configuration);

var app = builder.Build();

app.Run();