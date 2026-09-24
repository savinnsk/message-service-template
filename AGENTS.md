# Agent Guide

This file gives AI coding agents the project context and rules needed to work safely in this repository.

## Project Summary

`message-service` is a .NET 10 ASP.NET Core Web API for sending and managing messages through multiple providers.

Current providers:

- `EvolutionGo`: unofficial WhatsApp instance and message operations.
- `MetaApi`: official WhatsApp Cloud API message, account, phone, WABA, verification, and webhook-related operations.

Planned direction:

- Add more providers, including Evolution API and Telegram.
- Add Redis for chat context and short-lived conversation state.
- Move toward a unified provider abstraction, but keep the current provider-specific routes until that contract exists.

## Solution Layout

```text
src/
  Application/  HTTP API, controllers, app startup, API documentation
  Services/     Use cases and orchestration between controllers and provider clients
  Infra/        External provider HTTP clients, provider options, HttpClient setup
  Domain/       DTOs, records, shared contracts
```

Respect this layer direction:

```text
Application -> Services -> Infra -> Domain
```

`Domain` must not depend on other projects. `Infra` should not depend on `Application`. Controllers should not call provider clients directly.

## Core Patterns

### Controllers

Controllers live in `src/Application/Controllers`.

Use controllers only for HTTP concerns:

- Route attributes.
- Binding route/body parameters.
- Calling the corresponding service.
- Returning `HttpResult.From(result)` for `Result<string>`.

Keep controllers thin. Do not put provider HTTP logic in controllers.

Existing examples:

- `src/Application/Controllers/MetaApi/MessageController.cs`
- `src/Application/Controllers/MetaApi/AccountController.cs`
- `src/Application/Controllers/EvoGo/InstanceController.cs`

Provider route prefixes:

- Meta account: `api/meta/account`
- Meta message: `api/meta/message`
- EvoGo instance: `api/evogo/instance`
- EvoGo message: `api/evogo/message`

For Meta request bodies that need runtime provider options, use the existing shape:

```json
{
  "options": {
    "version": "v20.0",
    "numberId": "WHATSAPP_PHONE_NUMBER_ID"
  },
  "data": {}
}
```

For Meta message sending, the current shape is:

```json
{
  "options": {},
  "message": {}
}
```

### Services

Services live in `src/Services/Providers/{ProviderName}`.

Services are concrete classes. This project currently does not use service interfaces.

Services should:

- Receive provider clients through constructor injection.
- Expose use-case methods with clear names.
- Return `Task<Result<string>>` when proxying provider responses.
- Avoid HTTP request construction details unless orchestration is needed.

Existing examples:

- `src/Services/Providers/MetaApi/AccountService.cs`
- `src/Services/Providers/MetaApi/MessageService.cs`
- `src/Services/Providers/EvolutionGo/InstanceService.cs`

### Infra Providers

Provider clients live in `src/Infra/Providers/{ProviderName}`.

Infra classes own:

- External provider URLs and endpoints.
- `HttpRequestMessage` construction.
- Serialization with `JsonContent.Create`.
- Calling `HttpClient`.
- Reading response bodies.
- Mapping provider responses into `Result<string>`.
- Provider-specific logging.

The common return pattern is:

```csharp
return new Result<string>(
    Success: result.IsSuccessStatusCode,
    Data: body,
    Error: result.IsSuccessStatusCode ? null : body,
    StatusCode: (int)result.StatusCode
);
```

Do not throw for non-success HTTP status codes. Return `Result<string>` with `Success = false`. Throw only for unexpected exceptions after logging.

### Domain

DTOs and records live in `src/Domain`.

Use `System.Text.Json.Serialization.JsonPropertyName` for provider JSON contracts when the external API uses snake_case or specific field names.

Shared result type:

```csharp
Domain.Records.Result<T>
```

Message normalization record:

```csharp
Domain.Records.InboundMessageRequest
```

## Dependency Injection

Always register new services and provider clients.

Application startup calls:

```csharp
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddServices();
```

Register service-layer classes in:

```text
src/Services/DependencyInjection.cs
```

Current style:

```csharp
services.AddScoped<Providers.MetaApi.AccountService>();
```

Register typed `HttpClient` provider clients in:

```text
src/Infra/DependencyInjection.cs
```

Current Meta style:

```csharp
services.AddHttpClient<Account>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<MetaApiWppOptions>>().Value;
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", options.MetaToken);
});
```

## Configuration

Use `src/Application/appsettings.Example.json` as the template.

Do not commit real tokens.

Current sections:

```json
{
  "EvolutionGo": {
    "EvolutionGoUri": "http://localhost:8080",
    "EvolutionGoToken": "token"
  },
  "MetaApi": {
    "MetaToken": "token"
  }
}
```

Meta per-request options are passed in request bodies through `MetaOptions`, usually including Graph API `version` and WhatsApp `numberId`.

## Coding Rules

- Keep changes scoped to the requested provider, layer, or use case.
- Prefer the existing concrete-class pattern over adding interfaces.
- Use primary constructors where the surrounding code already uses them.
- Use async provider methods returning `Task<Result<string>>`.
- Keep `HttpResult.From(result)` as the standard controller response for provider JSON responses.
- Preserve provider-specific DTO names and JSON field names.
- Do not move provider-specific details into `Application`.
- Do not introduce a new abstraction layer unless explicitly requested or clearly needed.
- Do not commit secrets, tokens, phone numbers, WABA IDs, or business IDs.

## Validation

Before finishing code changes, run:

```bash
dotnet build
```

Known current warnings may include:

- `Microsoft.OpenApi` package vulnerability warning.
- Nullable warning in `MetaWebhookController`.

Do not treat those existing warnings as new failures unless the task is about warnings or dependency upgrades.

## Common Implementation Checklist

When adding a provider operation:

1. Add or update DTOs in `Domain` if the provider request body needs a typed model.
2. Add the HTTP operation in the relevant `Infra` provider client.
3. Add a pass-through or orchestration method in the matching `Services` class.
4. Add a thin endpoint in the matching `Application` controller.
5. Register new services or provider clients in dependency injection.
6. Build the solution with `dotnet build`.

