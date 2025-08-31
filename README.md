# RESTFulApi

A professional RESTful API built with ASP.NET Core 8 following Clean Architecture, SOLID principles, Repository & Unit of Work patterns, and FluentValidation. The API manages Categories and Products with full CRUD functionality.

## Table of Contents
- [Features](#features)
- [Architecture](#architecture)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Database Migrations](#database-migrations)
- [API Endpoints](#api-endpoints)
- [Validation](#validation)
- [Swagger](#swagger)
- [Contributing](#contributing)
- [License](#license)

## Features
- Clean architecture separation (Domain, Application, Infrastructure, WebApi)
- Repository and Service layers for clean separation of concerns
- Full CRUD operations for Categories and Products
- DTOs for input/output abstraction
- AutoMapper for object mapping
- FluentValidation for robust input validation
- EF Core with SQL Server (or any provider)
- Swagger/OpenAPI support for API testing
- Timestamps and auditing (CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)

## Architecture
**WebApi (Presentation Layer)**
```
└── Controllers
```

**Application (Application Layer)**
```
├── DTOs
├── Services (Business logic)
├── Abstractions (Interfaces)
├── Validators
└── Mapping (AutoMapper)
```

**Domain (Domain Layer)**
```
└── Entities
```

**Infrastructure (Infrastructure Layer)**
```
├── DbContext
└── Repositories (EF Core)
```

- **WebApi** → Handles HTTP requests and responses.  
- **Application** → Contains service contracts, business logic, DTOs, validators, and AutoMapper profiles.  
- **Domain** → Contains entity definitions.  
- **Infrastructure** → Handles data access and DbContext.  

## Technologies
- .NET 8 / ASP.NET Core 8
- Entity Framework Core 8
- AutoMapper
- FluentValidation v11+
- SQL Server (or any EF Core provider)
- Swagger / Swashbuckle
- Dependency Injection & SOLID Principles

## Project Structure
```
src/
 ├── WebApi/             
 │    └── Controllers/
 ├── Application/
 │    ├── Abstractions/
 │    │     ├── Services/
 │    │     └── Repositories/
 │    ├── DTOs/
 │    ├── Validators/
 │    └── Mapping/
 ├── Domain/
 │    └── Entities/
 └── Infrastructure/
      ├── Context/
      └── Repositories/
```

## Getting Started

Clone the repository:
```bash
git clone https://github.com/YourUsername/RESTFulApi.git
cd RESTFulApi
```

Set up connection string in `appsettings.json` (WebApi project):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RESTFulApiDb;Trusted_Connection=True;"
}
```

Install dependencies:
```bash
dotnet restore
```

## Database Migrations

Create migration:
```bash
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project WebApi
```

Update database:
```bash
dotnet ef database update --project Infrastructure --startup-project WebApi
```

This will create `Categories` and `Products` tables with all necessary fields.

## API Endpoints

### Categories
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/Category        | Get all categories |
| GET    | /api/Category/{id}   | Get category by ID |
| POST   | /api/Category        | Create category |
| PUT    | /api/Category/{id}   | Update category |
| DELETE | /api/Category/{id}   | Delete category |

### Products
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/Product        | Get all products |
| GET    | /api/Product/{id}   | Get product by ID |
| POST   | /api/Product        | Create product |
| PUT    | /api/Product/{id}   | Update product |
| DELETE | /api/Product/{id}   | Delete product |

## Validation
- All create/update requests are validated using **FluentValidation**.  
- Invalid requests return **400 Bad Request** with detailed error messages.  

## Swagger
API comes with Swagger UI for testing:  
```
https://localhost:{port}/swagger
```
Automatically documents all endpoints and DTOs.  

## Contributing
- Follow **Clean Architecture** for new features.  
- Use **DTOs** for input/output.  
- Add **FluentValidation** rules for new models.  
- Maintain **SOLID principles**.  

## License
This project is **MIT licensed**.
