# Entity Framework Core - First SQL Connection (ASP.NET Core Web API)

This repository is my first hands-on project using **Entity Framework Core** with a real **SQL Server** connection in an **ASP.NET Core Web API**.

## What I learned / used
- **Entities / Models**
- **DbContext (RepositoryContext)**
- **Connection String** (appsettings.json)
- **Migrations** (Add-Migration, Update-Database)
- **Type Configuration** (e.g., precision/constraints)
- **Inversion of Control / Dependency Injection** (DbContext registration)
- **API Testing** (Swagger / Postman)

## Tech Stack
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

## Run
1. Update the connection string in `appsettings.json`
2. Apply migrations:
   - `Add-Migration InitialCreate`
   - `Update-Database`
3. Run the project and test via `/swagger`
