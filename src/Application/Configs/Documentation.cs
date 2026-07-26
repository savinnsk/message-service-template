using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

namespace Application.Configs;

public static class DocumentationConfiguration
{

    public static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference("/docs");

        return app;
    }
    
}