# MovieDatabase
MovieDatabase is the ASP.NET Core Web API project.
Startup projects are MovieDatabase and MovieDatabase.IdentityHost (without debugging).

# Steps to run application
Open MovieDatabase -> appsettings.Development.json and change:
  1) Set Server in the "ConnectionStrings" -> "DefaultConnection" and in the "Serilog" -> "connectionString" instead of "serverName";
  2) Set your autorithaion address insted of "localhost:44362" in the "Swagger" -> "Authorization" -> "Domain" + "TokenUrl" + "AuthorizationUrl" + "ManagementApiUsersEndpoint" + "Authority";

# Authentication
Authentication uses for the MoviesController. You can execute its methods after authentication. 
The industry-standard protocol for authorization is OAuth 2.0.

Credentials:

ClientId: movie.client

Password: SuperSecretPassword

## Database

Change connection string ypu can ih the MovieDatabase -> appsettings.Development.json -> "ConnectionStrings" -> "DefaultConnection" 
MsSQL is used. 

## Logging

The application supports logging via using Serilog.

## Swagger

Helps to understand the capabilities of a REST API without direct access to the source code.

## Mapping

AutoMapper is used for mapping.

## CQRS and MediatR

CQRS (The Command and Query Responsibility Segregation) separates read and update operations for a data store.
MediatR allows the exchange of messages between the controller and requests / commands without dependencies.

