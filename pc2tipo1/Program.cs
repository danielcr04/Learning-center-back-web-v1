using Pc2_Tipo1.API.Sale.Application.Internal.CommandServices;
using Pc2_Tipo1.API.Sale.Domain.Repositories;
using Pc2_Tipo1.API.Sale.Domain.Services;
using Pc2_Tipo1.API.Sale.Infrastructure.Persistence.EFC.Repositories;
using Pc2_Tipo1.API.Shared.Domain.Repositories;
using Pc2_Tipo1.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Pc2_Tipo1.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pc2_Tipo1.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Configure routing to use lowercase and kebab-case in URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Configure database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
    throw new InvalidOperationException("Connection string is null");

// Configure database context and logging for debugging
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging();
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hialpesa Purchase Orders API",
        Version = "v1",
        Description = "RESTful API for managing purchase orders in the Hialpesa platform"
    });
});

// Dependency Injection Configuration

// Shared bounded context services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Sale bounded context services
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderCommandService, PurchaseOrderCommandService>();

var app = builder.Build();

// Ensure database schema and tables are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
