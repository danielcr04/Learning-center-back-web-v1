# 🧩 Proyecto

### Tipo
- Web API (.NET 9)
- Lenguaje: C#

---

# 📦 Dependencias

Agregadas mediante: `Tools > NuGet > Manage NuGet Packages`

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Relational`
- `Microsoft.EntityFrameworkCore.Relational.Design`
- `EntityFrameworkCore.CreatedUpdatedDate`
- `Swashbuckle.AspNetCore`
- `Swashbuckle.AspNetCore.Annotations`
- `Humanizer`
- `MySql.EntityFrameworkCore` 
- `Microsoft.Extensions.DependencyInjection`

---

# 📁 Estructura de Carpetas

## 1. `Shared`

```
Shared/
├── Domain/
│   └── Repositories/
│       ├── IBaseRepository.cs
│       └── IUnitOfWork.cs
│
└── Infrastructure/
    ├── Interfaces/ASP/Configuration/
    │   ├── Extensions/
    │   │   └── StringExtensions.cs
    │   └── KebabCaseRouteNamingConvention.cs
    │
    └── Persistence/EFC/
        ├── Configuration/
        │   └── Extensions/
        │       ├── ModelBuilderExtensions.cs
        │       └── StringExtensions.cs
        ├── AppDbContext.cs
        └── Repositories/
            ├── BaseRepository.cs
            └── UnitOfWork.cs
```

## 2. `Sale` (Bounded Context)

```
Sale/
├── Domain/
│   ├── Model/
│   │   ├── Aggregates/
│   │   ├── Commands/
│   │   └── ValueObjects/
│   ├── Repositories/
│   │   └── IPurchaseOrderRepository.cs
│   └── Services/
│       └── IPurchaseOrderCommandService.cs
│
├── Application/
│   └── Internal/
│       └── CommandServices/
│           └── PurchaseOrderCommandService.cs
│
├── Infrastructure/
│   └── Persistence/EFC/Repositories/
│       └── PurchaseOrderRepository.cs
│
└── Interfaces/
    ├── Controllers/
    │   └── PurchaseOrdersController.cs
    ├── Resources/
    │   ├── CreatePurchaseOrderResource.cs
    │   └── PurchaseOrderResource.cs
    └── Transform/
        └── CreatePurchaseOrderCommandFromResourceAssembler.cs
```

---

# ⚙️ Configuraciones Clave

## ✅ `Program.cs`

// Sale bounded context services
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderCommandService, PurchaseOrderCommandService>();


## ✅ `AppDbContext.cs`

 // SALE Context
        builder.Entity<PurchaseOrder>().HasKey(p => p.Id);

        builder.Entity<PurchaseOrder>().Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<PurchaseOrder>().Property(p => p.Customer)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<PurchaseOrder>().ToTable(t =>
            t.HasCheckConstraint("CK_PurchaseOrder_Customer_Length", "CHAR_LENGTH(customer) >= 4"));

        builder.Entity<PurchaseOrder>().Property(p => p.PoNumber)
            .IsRequired();

        builder.Entity<PurchaseOrder>().Property(p => p.FabricId)
            .IsRequired();

        builder.Entity<PurchaseOrder>().Property(p => p.Vendor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<PurchaseOrder>().ToTable(t =>
            t.HasCheckConstraint("CK_PurchaseOrder_Vendor_Length", "CHAR_LENGTH(vendor) >= 4"));

        builder.Entity<PurchaseOrder>().Property(p => p.ShipTo)
            .IsRequired();

        builder.Entity<PurchaseOrder>().Property(p => p.Quantity)
            .IsRequired();
        

## ✅ `appsettings.json`

"ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=root;password=Upc123;database=hialpesa"
  }

---

# 🌐 Cambiar el puerto de ejecución

Edita el archivo:

```
Properties/launchSettings.json
```
	
Modificaen htttp:
 
```json
"applicationUrl": "https://localhost:5049"
```

Ejemplo nuevo puerto:

```json
"applicationUrl": "https://localhost:7989"
```


---

# ✅ Implementado

http://localhost:5070/swagger/index.html

- [x] 1 Endpoint: `POST /api/v1/purchase-orders`
- [x] Validaciones de negocio
- [x] Puerto configurado
- [x] Internacionalización opcional si se requiere
