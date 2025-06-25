using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;
using Pc2_Tipo1.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace Pc2_Tipo1.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context for the Learning Center Platform
/// </summary>
/// <param name="options">
///     The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   /// <summary>
   ///     On configuring the database context
   /// </summary>
   /// <remarks>
   ///     This method is used to configure the database context.
   ///     It also adds the created and updated date interceptor to the database context.
   /// </remarks>
   /// <param name="builder">
   ///     The option builder for the database context
   /// </param>
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

   /// <summary>
   ///     On creating the database model
   /// </summary>
   /// <remarks>
   ///     This method is used to create the database model for the application.
   /// </remarks>
   /// <param name="builder">
   ///     The model builder for the database context
   /// </param>
   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure the entity properties and relationships here
        
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
        
        builder.UseSnakeCaseNamingConvention();
    }
}