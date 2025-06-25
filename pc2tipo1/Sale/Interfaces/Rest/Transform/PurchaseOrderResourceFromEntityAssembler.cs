using Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;
using Pc2_Tipo1.API.Sale.Interfaces.Rest.Resources;

namespace Pc2_Tipo1.API.Sale.Interfaces.Rest.Transform;

/// <summary>
/// Assembler to create a <see cref="PurchaseOrderResource"/> from a <see cref="PurchaseOrder"/> entity.
/// </summary>
/// <remarks>
/// Created by Daniel Crispin Ramos.
/// </remarks>
public static class PurchaseOrderResourceFromEntityAssembler
{
    /// <summary>
    /// Creates a <see cref="PurchaseOrderResource"/> from a <see cref="PurchaseOrder"/> entity.
    /// </summary>
    /// <param name="entity">
    /// The <see cref="PurchaseOrder"/> entity to transform into a resource.
    /// </param>
    /// <returns>
    /// A <see cref="PurchaseOrderResource"/> instance representing the purchase order data for the API response.
    /// </returns>
    public static PurchaseOrderResource ToResourceFromEntity(PurchaseOrder entity)
    {
        return new PurchaseOrderResource(
            entity.Id,
            entity.Customer,
            entity.PoNumber,
            entity.FabricId,
            entity.Vendor,
            entity.ShipTo,
            entity.Quantity
        );
    }
}