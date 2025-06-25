using Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;
using Pc2_Tipo1.API.Shared.Domain.Repositories;

namespace Pc2_Tipo1.API.Sale.Domain.Repositories;

public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
{
    /// <summary>
    /// Checks if a purchase order exists with the given customer and PO number
    /// </summary>
    /// <param name="customer">The customer name</param>
    /// <param name="poNumber">The purchase order number</param>
    /// <returns>True if exists, false otherwise</returns>
    Task<bool> ExistsPurchaseOrderByCustomerAndPoNumber(string customer, string poNumber);
}