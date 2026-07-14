using Application.Configs;
using message_service.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddDocumentation();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
       app.UseDocumentation();

//}


app.UseHttpsRedirection();
app.MapControllers();

app.Run();