	 	 	Proyecto
--------
Web
net9.0 C# WebAPI

Dependencias
------------
Tools -> NuGet -> Manage
Microsoft.EntityFrameworkCore
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore.Annotations
MySql.EntityFrameworkCore
EntityFrameworkCore.CreatedUpdatedDate
Humanizer
Microsoft.EntityFrameworkCore.Relational
Microsoft.EntityFrameworkCore.Relational.Design
Microsoft.Extensions.DependencyInjection (?)

Carpetas
--------
1. Shared
   1.1. Domain
	1.1.1. Repositories (IBaseRepository.cs, IUnitOfWork.cs)
   1.2. Infrastructure
	1.2.1. Interfaces/ASP/Configuration
	   1.2.1.1. Extensions (StringExtensions.cs)
	   KebabCaseRouteNamingConvention.cs
	1.2.2. Persistence/EFC
	   1.2.2.1. Configuration/Extensions (ModelBuilderExtensions.cs, StringExtensions.cs)
	   AppDbContext.cs
	   1.2.2.2. Repositories (BaseRepository.cs, UnitOfWork.cs)

Copiar la carpeta Shared en proyecto
Cambiar los imports


Bounded
	Domain
		Model
			ValueObjects
			Aggregate
			Command
		services
			IPurchaseOrderCommandService
		repositories
			IPurchaseOrderRepository

	
	Infrastructure/Persistence/EFC/Repositories/(name)Repository
	
	Application/Internal/CommandServices (Lógica si existe repeticion)
	Interfaces
		Resources
		Transform
		Controller

Configurar el Program.cs

Configurar el AppDbContext.cs

Configurar el appsettings.json
para el esquema según el nombre

Para cambiar de puerto en el http




Ejecute
1 Endpoint
Puerto
Internacionalizacion




































