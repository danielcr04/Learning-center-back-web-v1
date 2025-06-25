using Microsoft.EntityFrameworkCore;
using Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;
using Pc2_Tipo1.API.Sale.Domain.Repositories;
using Pc2_Tipo1.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Pc2_Tipo1.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Pc2_Tipo1.API.Sale.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository implementation for PurchaseOrder aggregate
/// </summary>
/// <remarks>
/// This class provides data access operations for PurchaseOrder entities.
/// Created by Daniel Crispin Ramos
/// </remarks>
public class PurchaseOrderRepository(AppDbContext context) 
    : BaseRepository<PurchaseOrder>(context), IPurchaseOrderRepository
{
    /// <inheritdoc />
    public async Task<bool> ExistsPurchaseOrderByCustomerAndPoNumber(string customer, string poNumber)
    {
        return await Context.Set<PurchaseOrder>()
            .AnyAsync(po => po.Customer == customer && po.PoNumber == poNumber);
    }
}