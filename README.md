# Password Manager API

A secure and robust password management system built with ASP.NET Core 8.0, implementing Clean Architecture principles and CQRS pattern. This API provides comprehensive user authentication and password storage capabilities with enterprise-level security features.

## 🚀 Features

### Core Features
- **User Management**: Complete user registration, authentication, and profile management
- **Password Storage**: Secure storage and management of passwords for different services
- **JWT Authentication**: Token-based authentication system with configurable expiration
- **Password Encryption**: Dual-layer security with BCrypt for master passwords and AES for stored passwords
- **RESTful API**: Well-designed REST endpoints following industry standards

### Technical Features
- **Clean Architecture**: Separation of concerns with Domain, Application, Infrastructure, and API layers
- **CQRS Pattern**: Command Query Responsibility Segregation using MediatR
- **FluentValidation**: Comprehensive input validation with custom error messages
- **AutoMapper**: Object-to-object mapping for DTOs and domain models
- **Entity Framework Core**: Code-first database approach with PostgreSQL
- **Swagger Documentation**: Interactive API documentation and testing interface

## 🏗️ Architecture

The project follows Clean Architecture principles with the following structure:

```
PasswordManager/
├── PasswordManager.Api/              # API Layer (Controllers, Middleware)
├── PasswordManager.Application/      # Application Layer (Business Logic, DTOs, Features)
├── PasswordManager.Domain/          # Domain Layer (Entities, Interfaces)
├── PasswordManager.Infrastructure/  # Infrastructure Layer (Data Access, External Services)
└── README.md
```

### Layer Responsibilities

- **Domain**: Core business entities and interfaces
- **Application**: Business logic, CQRS handlers, DTOs, validation, and mapping
- **Infrastructure**: Data access, external services, and cross-cutting concerns
- **API**: Controllers, middleware, and configuration

## 🛠️ Technology Stack

- **Framework**: .NET 8.0
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 8.0
- **Authentication**: JWT Bearer Token
- **Password Hashing**: BCrypt.Net
- **Encryption**: AES (Advanced Encryption Standard)
- **Validation**: FluentValidation
- **Documentation**: Swagger/OpenAPI
- **Architecture Patterns**: Clean Architecture, CQRS, Repository Pattern

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 12+](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## ⚙️ Installation

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/PasswordManager.git
cd PasswordManager
```

### 2. Database Setup
1. Install PostgreSQL and create a new database:
```sql
CREATE DATABASE AppDb;
```

2. Update the connection string in `PasswordManager.Api/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=AppDb;Username=your_username;Password=your_password"
  }
}
```

### 3. Configure JWT Settings
Update the JWT configuration in `appsettings.json`:
```json
{
  "JwtSettings": {
    "Secret": "YourSecretKeyHere-MustBe32CharactersLong!",
    "Issuer": "PasswordManagerAPI",
    "Audience": "PasswordManagerClient",
    "ExpiryMinutes": 60
  }
}
```

### 4. Install Dependencies
```bash
dotnet restore
```

### 5. Run Database Migrations
```bash
dotnet ef database update --project PasswordManager.Infrastructure --startup-project PasswordManager.Api
```

### 6. Run the Application
```bash
dotnet run --project PasswordManager.Api
```

The API will be available at:
- HTTP: `http://localhost:5187`
- HTTPS: `https://localhost:7237`
- Swagger UI: `https://localhost:7237/swagger`

## 📚 API Documentation

### Authentication Endpoints

#### Register User
```http
POST /api/auth/register
Content-Type: application/json

{
  "userName": "john_doe",
  "email": "john@example.com",
  "password": "SecurePass123!"
}
```

#### Login User
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "john@example.com",
  "password": "SecurePass123!"
}
```

### User Management Endpoints

#### Get User by ID
```http
GET /api/users/{id}
Authorization: Bearer {jwt_token}
```

#### Update User
```http
PUT /api/users/{id}
Authorization: Bearer {jwt_token}
Content-Type: application/json

{
  "id": 1,
  "userName": "updated_username",
  "email": "updated@example.com",
  "password": "NewPassword123!"
}
```

#### Get All Users
```http
GET /api/users/UserList
Authorization: Bearer {jwt_token}
```

### Password Management Endpoints

#### Create Password Entry
```http
POST /api/passwords
Authorization: Bearer {jwt_token}
Content-Type: application/json

{
  "userId": 1,
  "name": "GitHub",
  "username": "myusername",
  "password": "MySecurePassword123!"
}
```

#### Get Password by ID
```http
GET /api/passwords/{id}
Authorization: Bearer {jwt_token}
```

#### Update Password Entry
```http
PUT /api/passwords/{id}
Authorization: Bearer {jwt_token}
Content-Type: application/json

{
  "id": 1,
  "userId": 1,
  "name": "GitHub",
  "username": "myusername",
  "password": "UpdatedPassword123!"
}
```

#### Get All Passwords
```http
GET /api/passwords/PasswordList
Authorization: Bearer {jwt_token}
```

## 🔒 Security Features

### Password Security
- **Master Passwords**: Hashed using BCrypt with salt
- **Stored Passwords**: Encrypted using AES-256 encryption
- **Secure Key Management**: Configurable encryption keys

### Authentication & Authorization
- **JWT Tokens**: Stateless authentication with configurable expiration
- **Bearer Token Authentication**: Standard HTTP authorization headers
- **Role-based Access**: Secure access control to resources

### Input Validation
- **Comprehensive Validation**: All inputs validated using FluentValidation
- **Password Requirements**: Enforced strong password policies
- **Data Sanitization**: Protection against injection attacks

## 🧪 Testing

### Run Unit Tests
```bash
dotnet test
```

### API Testing
Use the integrated Swagger UI for interactive API testing:
1. Navigate to `https://localhost:7237/swagger`
2. Use the "Authorize" button to set your JWT token
3. Test endpoints directly from the browser

## 🔧 Configuration

### Environment Variables
Key configuration options in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your PostgreSQL connection string"
  },
  "JwtSettings": {
    "Secret": "Your JWT secret key (32+ characters)",
    "Issuer": "Your application name",
    "Audience": "Your client name",
    "ExpiryMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## 🚀 Deployment

### Production Deployment
1. **Environment Configuration**: Update connection strings and JWT settings
2. **Database Migration**: Run migrations in production environment
3. **Security**: Use environment variables for sensitive configuration
4. **HTTPS**: Ensure SSL/TLS certificates are properly configured

### Docker Support (Optional)
Create a `Dockerfile` for containerization:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PasswordManager.Api.dll"]
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines
- Follow Clean Architecture principles
- Implement comprehensive unit tests
- Use FluentValidation for input validation
- Follow RESTful API conventions
- Update documentation for new features

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

For support, questions, or contributions:
- Create an issue on GitHub
- Contact the development team
- Check the documentation in the `/docs` folder

## 🔄 Version History

- **v1.0.0** - Initial release with core functionality
  - User authentication and management
  - Password storage and encryption
  - JWT-based security
  - RESTful API endpoints

---

**Note**: This is a demonstration project. For production use, ensure proper security audits, monitoring, and compliance with relevant data protection regulations.
