# E-Commerce Platform API using .NET Core 7 with Onion Architecture and CQRS Pattern
## Description:

This repository contains the implementation of a scalable and maintainable web API for an e-commerce platform, inspired by the Hepsiburada structure, using .NET Core 7. The project is designed following the Onion Architecture combined with the CQRS (Command Query Responsibility Segregation) design pattern to achieve a clean separation of concerns and ensure high testability, flexibility, and scalability.

## Key Features:

.NET Core 7: Utilizes the latest features and improvements from .NET Core 7 for building a modern and performant web API. 

Onion Architecture: Implements a layered approach to isolate core business logic from external concerns, such as data access and UI. 

CQRS Pattern: Separates command and query responsibilities, optimizing for both read and write operations, enhancing performance and maintainability.

Entity Framework Core: Used for data persistence, with support for migrations and database seeding. 

Dependency Injection: Follows SOLID principles by injecting dependencies, ensuring loose coupling and easier testing.  

Automated Testing: Includes unit tests for core business logic and integration tests for API endpoints. 

Swagger Integration: Provides a user-friendly interface for exploring and testing API endpoints.

## Folder Structure:

Core: Contains the domain models, interfaces, and business logic.

Infrastructure: Handles data access, third-party integrations, and external services.

Application: Implements the CQRS pattern, handling the application’s command and query processing.

API: The entry point of the application, exposing RESTful endpoints to interact with the e-commerce platform.

## Getting Started:

Clone the repository: git clone https://github.com/yourusername/ecommerce-platform-api.git

Navigate to the project directory: cd ecommerce-platform-api

Install dependencies: dotnet restore

Apply migrations: dotnet ef database update

Run the application: dotnet run
## Technologies Used:

.NET Core 7

Entity Framework Core

MediatR (for CQRS implementation)

AutoMapper

Swagger

## Learning Experience: 
Throughout this project, I gained significant insights into advanced .NET Core concepts, particularly focusing on the application of Onion Architecture and the CQRS pattern in real-world scenarios. I deepened my understanding of how to structure large-scale applications for maintainability and scalability. Additionally, working with dependency injection, MediatR, and Entity Framework Core provided me with hands-on experience in managing complex business logic and ensuring high-performance data operations. This project also helped me enhance my skills in writing clean, testable code and developing APIs that follow best practices for security and usability.

[] Projede kullanılan kütüphaneler, çalıştırılmadan önce indirilecekler, redisin çalıştırılması gerektiği gibi yerleri de buraya ekle mutlaka

https://github.com/microsoftarchive/redis/releases  
Redis-x64-3.0.504.zip

