# PC Store Backend

Production-oriented ASP.NET Core backend starter for an online PC and computer-components store.

## Architecture

- `PcStore.Api` — HTTP endpoints, middleware, dependency injection
- `PcStore.Application` — use cases, DTOs, abstractions
- `PcStore.Domain` — entities and business rules
- `PcStore.Infrastructure` — EF Core, PostgreSQL, repositories
- `PcStore.DataAccess` — EF Core context, configurations, repositories, seed data, and migrations
- `PcStore.Infrastructure` — external integrations such as authentication, payments, email, caching, and storage
- `PcStore.Tests` — automated tests

## Initial modules

- Catalog: products, categories, brands, and specifications
- Inventory: SKUs, stock, reservations, and stock movements
- Identity: customers, administrators, roles, and permissions
- Shopping: carts and wishlists
- Sales: orders, payments, shipping, promotions, returns, and warranties

## Run locally

Requirements: .NET 8 SDK and Docker.

```bash
docker compose up -d postgres
dotnet restore
dotnet ef database update --project src/PcStore.DataAccess --startup-project src/PcStore.Api
dotnet run --project src/PcStore.Api
```

Swagger is available in Development at `/swagger`.

## Status

The first vertical slice includes a health endpoint and paginated product listing. Authentication, checkout, payment-provider integration, and stock reservation are prepared as module folders for later implementation.
