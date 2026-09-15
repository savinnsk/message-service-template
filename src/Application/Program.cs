using Application.Configs;
using Infra;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddDocumentation();

var app = builder.Build();



//if (app.Environment.IsDevelopment()){
       app.UseDocumentation();
       app.Use(async (context, next) =>
       {
              Console.WriteLine("======= REQUEST =======");
              Console.WriteLine($"Path: {context.Request.Path}");
              Console.WriteLine($"QueryString: {context.Request.QueryString}");
              foreach (var query in context.Request.Query)
              {
                     Console.WriteLine($"{query.Key} = {query.Value}");
              }
              Console.WriteLine("=======================");
              await next();
       });
//}


app.UseHttpsRedirection();
app.MapControllers();

app.Run();