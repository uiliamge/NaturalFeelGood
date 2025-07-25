# NaturalFeelGood

<p align="center">
  <img src="Infrastructure/Assets/Images/logo-full.png" alt="NaturalFeelGood Logo" width="320" />
</p>

NaturalFeelGood is a modular .NET 8 web application designed to manage and provide information about natural remedies, alternative treatments, and related entities. The solution follows clean architecture principles, separating domain, application, and infrastructure layers.

## Solution Structure

- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" alt="ASP.NET Core" width="24" height="24" /> **NaturalFeelGood**: ASP.NET Core Web API project. Entry point for the application.
- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="C#" width="24" height="24" /> **Domain**: Contains core business entities and value objects (e.g., `RemedyAlternative`, `Medication`).
- <img src="https://img.shields.io/badge/CQRS-MediatR-blue?logo=mediatr" alt="CQRS" width="90" height="20" /> **Application**: Implements business logic, MediatR commands/queries, and interfaces.
- <img src="https://img.shields.io/badge/DynamoDB-AWS-blue?logo=amazon-dynamodb&logoColor=white" alt="DynamoDB" width="90" height="20" /> **Infrastructure**: Handles data persistence (DynamoDB), configuration, and repository implementations.
- <img src="https://img.shields.io/badge/S3-AWS-orange?logo=amazon-aws&logoColor=white" alt="S3" width="60" height="20" /> **S3 Integration**: Handles file and object storage using Amazon S3 buckets.

## Main Features

- **Entity Management**: CRUD operations for remedies, element types, and other domain entities.
- <img src="https://img.shields.io/badge/DynamoDB-AWS-blue?logo=amazon-dynamodb&logoColor=white" alt="DynamoDB" width="90" height="20" /> **DynamoDB Integration**: Generic context for flexible access to tables and basic CRUD operations.
- <img src="https://img.shields.io/badge/S3-AWS-orange?logo=amazon-aws&logoColor=white" alt="S3" width="60" height="20" /> **S3 Bucket Integration**: Store and retrieve files and assets using Amazon S3.
- <img src="https://img.shields.io/badge/CQRS-MediatR-blue?logo=mediatr" alt="CQRS" width="90" height="20" /> **CQRS Pattern**: MediatR for command and query separation.
- <img src="https://img.shields.io/badge/Validation-FluentValidation-green" alt="FluentValidation" width="110" height="20" /> **Validation**: FluentValidation for input validation.
- <img src="https://img.shields.io/badge/Mapping-AutoMapper-orange" alt="AutoMapper" width="110" height="20" /> **Object Mapping**: AutoMapper for DTO/entity mapping.
- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/swagger/swagger-original.svg" alt="Swagger" width="24" height="24" /> **API Documentation**: Swagger (Swashbuckle) for interactive API documentation.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" alt="dotnet" width="24" height="24" />
- [Amazon DynamoDB](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Introduction.html) <img src="https://img.shields.io/badge/DynamoDB-AWS-blue?logo=amazon-dynamodb&logoColor=white" alt="DynamoDB" width="90" height="20" /> (local or AWS instance)
- [Amazon S3](https://docs.aws.amazon.com/s3/index.html) <img src="https://img.shields.io/badge/S3-AWS-orange?logo=amazon-aws&logoColor=white" alt="S3" width="60" height="20" /> (for file/object storage)
---

## License

This project is licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0).

> **NOTICE:**  
> The name “Natural Feel Good” and the domain “naturalfeelgood.com” are protected by Uiliam Goltz Elesbão as identifiers of the brand and may not be used, reused, or referenced in derivative projects, products, or publications without express written consent.

© 2025 Uiliam Goltz Elesbão. All rights reserved.
