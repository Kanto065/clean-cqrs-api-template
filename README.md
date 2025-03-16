# WebAPI Project - CQRS & Clean Architecture

## 📌 Overview

This project is a **Web API** designed using the **CQRS pattern** and **Clean Architecture**. It leverages **PostgreSQL** for command operations and **MongoDB** for query operations, ensuring high scalability and performance.

## 🚀 Technologies Used

- **ASP.NET Core** - Web API framework
- **CQRS Pattern** - Separation of concerns
- **Clean Architecture** - Maintainability & scalability
- **PostgreSQL** - Relational database for commands
- **MongoDB** - NoSQL database for queries
- **MediatR** - Implements CQRS pattern

## 🏗️ Architecture

The project follows **Clean Architecture**, separating concerns into distinct layers:

```
/src
 ├── Application  # Business logic, CQRS (MediatR)
 ├── Domain       # Core entities, aggregates, enums
 ├── Infrastructure # Database connections and dependencies
 ├── Presentation # API Layer (REST & Query Handlers)
 ├── Shared       # Common utilities, contracts
 ├── Tests        # Unit & Integration tests
 ├── WebApi       # Startup project
```

## ⚡ Features

✅ Implements **CQRS** with separate read and write models\
✅ Uses **PostgreSQL** for commands (REST API)\
✅ Uses **MongoDB** for queries\
✅ Supports **multi-tenancy**\
✅ Follows **SOLID Principles** and **Dependency Injection**

## 🔧 Setup & Installation

### Prerequisites

Ensure you have the following installed:

- .NET 8 SDK
- PostgreSQL
- MongoDB

### Installation Steps

1. **Clone the repository:**
   ```sh
   git clone https://github.com/clean-cqrs-api-template.git
   cd clean-cqrs-api-template
   ```
2. **Update connection strings in `appsettings.json`**
3. **Run database migrations:**
   ```sh
   dotnet ef database update
   ```
4. **Run the Web API:**
   ```sh
   dotnet run --project src/WebApi
   ```

## 🎯 Usage

- **Command API (REST):** `POST /api/User/Create` → Stores data in PostgreSQL
- **Query API:** `GET /api/User/GetAll` Fetches data from MongoDB

## 📜 License

This project is licensed under the [MIT License](LICENSE).

## 👨‍💻 Author

Developed by [Kanta Bhattacharjee](https://www.linkedin.com/in/bhattacharjee-kanta/). 

