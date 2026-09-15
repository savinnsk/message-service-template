# Message Service

Message Service is a .NET 10 Web API for sending and managing messages across multiple messaging providers.

The project is being built as a provider-agnostic messaging gateway. The API exposes HTTP endpoints, the service layer owns the messaging use cases, and the infrastructure layer talks to external providers such as EvoGo and Meta WhatsApp Cloud API.

## Current Capabilities

- WhatsApp through EvoGo for unofficial WhatsApp instance management and message sending.
- WhatsApp through Meta API for official WhatsApp Cloud API message sending.
- OpenAPI documentation with Scalar at `/docs`.
- Docker Compose support for EvoGo and Postgres.

## Planned Capabilities

- Redis for chat context storage, conversation state, and short-lived message/session data.
- Evolution API integration as another WhatsApp provider adapter.
- Telegram API integration for Telegram message delivery.
- A unified provider abstraction so callers can send messages without depending on provider-specific routes.

## Architecture

The solution is split into four main projects:

```text
src/
  Application/  HTTP API, controllers, API documentation, app startup
  Services/     Use cases and orchestration between API and providers
  Infra/        External integrations, HttpClient setup, provider configuration
  Domain/       DTOs, result records, and shared contracts
```

### Layer Responsibilities

`Application`

- Starts the ASP.NET Core application in `Program.cs`.
- Registers controllers, infrastructure services, application services, and API documentation.
- Exposes HTTP endpoints for EvoGo and Meta API.
- Converts domain `Result<T>` values into HTTP responses through `HttpResult`.

`Services`

- Contains business-facing message and instance services.
- Keeps controllers thin by delegating provider operations to service classes.
- Coordinates provider-specific infrastructure classes.

`Infra`

- Contains provider clients and integration details.
- Configures typed `HttpClient` instances for EvoGo and Meta API.
- Adds provider authentication headers and base URLs from configuration.

`Domain`

- Contains DTOs used by the API and provider integrations.
- Contains the shared `Result<T>` record used to return success, error, data, and status code information consistently.

## Provider Integrations

### EvoGo

EvoGo is currently used for unofficial WhatsApp instance and message operations.

Current instance endpoints:

| Method | Route | Description |
| --- | --- | --- |
| `POST` | `/api/evogo/instance/create` | Create a new EvoGo instance |
| `GET` | `/api/evogo/instance/qr/{instanceName}` | Get the QR connection data |
| `GET` | `/api/evogo/instance/status/{instanceToken}` | Check instance status |
| `DELETE` | `/api/evogo/instance/delete/{instanceId}` | Delete an instance |
| `POST` | `/api/evogo/instance/disconnect/{instanceToken}` | Disconnect an instance |
| `GET` | `/api/evogo/instance` | List all instances |
| `GET` | `/api/evogo/instance/get/{instanceId}` | Get one instance |

Current message endpoints:

| Method | Route | Description |
| --- | --- | --- |
| `POST` | `/api/evogo/message/{tokenInstance}` | Send text |
| `POST` | `/api/evogo/message/link/{tokenInstance}` | Send link |
| `POST` | `/api/evogo/message/media/{tokenInstance}` | Send media |
| `POST` | `/api/evogo/message/button/{tokenInstance}` | Send button message |
| `POST` | `/api/evogo/message/list/{tokenInstance}` | Send list message |

The EvoGo integration is implemented in `src/Infra/EvolutionGo/EvolutionGoIntegration.cs` and configured through:

```json
"EvolutionGo": {
  "EvolutionGoUri": "http://localhost:8080",
  "EvolutionGoToken": "sua-chave-segura-aqui"
}
```

### Meta API

Meta API is currently used for official WhatsApp Cloud API message sending through the Graph API.

Current message endpoints:

| Method | Route | Description |
| --- | --- | --- |
| `POST` | `/api/meta/message/text` | Send text message |
| `POST` | `/api/meta/message/list` | Send interactive list message |
| `POST` | `/api/meta/message/button` | Send interactive button message |

The Meta API integration is implemented in `src/Infra/MetaApiWpp/MetaApiMessage.cs`. It sends requests to:

```text
https://graph.facebook.com/{version}/{numberId}/messages
```

Meta API authentication is configured through:

```json
"MetaApi": {
  "MetaToken": "token"
}
```

Each request body includes provider options and the message payload:

```json
{
  "options": {
    "version": "v20.0",
    "numberId": "WHATSAPP_PHONE_NUMBER_ID"
  },
  "message": {
    "messaging_product": "whatsapp",
    "to": "5511999999999",
    "type": "text",
    "text": {
      "body": "Hello"
    }
  }
}
```

### Evolution API

Evolution API is planned as an additional WhatsApp provider adapter. The expected direction is to keep it isolated in `Infra`, expose use cases from `Services`, and avoid leaking Evolution API-specific request details into controllers once a unified provider contract is added.

### Telegram API

Telegram API is planned as a new provider integration. It should follow the same layering:

- Telegram DTOs and shared contracts in `Domain`.
- Telegram use cases in `Services`.
- Telegram HTTP client and authentication in `Infra`.
- HTTP routes or a future unified messaging endpoint in `Application`.

## Redis Chat Context

Redis is planned for chat context and conversation state. It should be used for data that needs fast access and does not belong directly in provider clients, such as:

- Active chat context by user, phone number, instance, or provider.
- Short-lived conversation state.
- Message correlation IDs and temporary delivery metadata.
- Provider session hints needed by future orchestration flows.

The recommended placement is:

- Redis contracts or context DTOs in `Domain`.
- Chat context services in `Services`.
- Redis connection, serialization, and cache implementation in `Infra`.

## Runtime Dependencies

The current `compose.yaml` starts:

- `postgres`, used by EvoGo.
- `evolution-go`, using the `evoapicloud/evolution-go:0.7.2-beta` image.

Start dependencies with:

```bash
docker compose up -d
```

## Running Locally

Restore and run the API:

```bash
dotnet restore MessageService.slnx
dotnet run --project src/Application/Application.csproj
```

Open the API documentation:

```text
https://localhost:<port>/docs
```

The local port is defined by ASP.NET Core launch settings or the runtime URL printed by `dotnet run`.

## Configuration

Use `src/Application/appsettings.Example.json` as the configuration template.

Required sections today:

```json
{
  "EvolutionGo": {
    "EvolutionGoUri": "http://localhost:8080",
    "EvolutionGoToken": "sua-chave-segura-aqui"
  },
  "MetaApi": {
    "MetaToken": "token"
  }
}
```

Do not commit real provider tokens.

## Roadmap

- Add Redis-backed chat context.
- Add Evolution API integration.
- Complete and harden EvoGo message operations.
- Expand Meta API support for more WhatsApp message types and webhook handling.
- Add Telegram API message sending.
- Introduce a unified messaging contract across providers.
- Add automated tests for controllers, services, and provider clients.
