using Application.Configs;
using Infra;
using message_service.Infra;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddDocumentation();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
       app.UseDocumentation();

//}


app.UseHttpsRedirection();
app.MapControllers();

app.Run();