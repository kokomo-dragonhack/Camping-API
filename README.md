# Camps API

Table of Contents
=================
- [Precondition](#precondition)
- [Installation and operation](#installation-and-operation)
- [Environment variables](#environment-variables)
- [Database](#database)


## Presentation video

- https://youtu.be/20yYPs08Vy0
- https://youtu.be/k0_4XvFMspk

## Precondition

Proper application running tested with the following development tools:
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
- [SSMS 17.x](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)


## Installation and operation

You can run app with Docker. 

- `cd code/Avtokampi`
- `docker build -f AvtokampiWebAPI/Dockerfile -t camps:latest .`
- `docker run -it camps`

When you have the development environment ready, run the following commands:

1. Open a project in Visual Studio
    - `Open project or solution -> find the downloaded folder and in the subfolder WebApp/ open .sln datoteko`
    - Perform as needed `Restore NuGet Packages`

2. Set up a connection to the database in Visual Studio
    - `Avtokampi -> appsettings.json -> "ConnectionStrings" -> "DefaultConnection"`
    
4. You can then launch the app



## Project structure

- Models -> Domain models and Data transfer models
- Services -> Service layer for business logic
- Repositories -> Repository layer for communication with database
- Controllers -> REST endpoints communication layer

## Link to Swagger docs

- https://camping-api.azurewebsites.net/
- https://camping-web.web.app/

You can try login with user:
- dabeu@cegu.com / string
