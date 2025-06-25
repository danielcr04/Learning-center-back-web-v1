using Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;
using Pc2_Tipo1.API.Sale.Domain.Model.Commands;

namespace Pc2_Tipo1.API.Sale.Domain.Services;

public interface IPurchaseOrderCommandService
{
    /// <summary>
    /// Handles the creation of a new purchase order
    /// </summary>
    /// <param name="command">The create purchase order command containing the purchase order data</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the created PurchaseOrder if successful, otherwise null.
    /// </returns>
    Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command);
}