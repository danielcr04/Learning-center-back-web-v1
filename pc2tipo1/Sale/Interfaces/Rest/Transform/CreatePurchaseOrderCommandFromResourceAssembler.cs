using Pc2_Tipo1.API.Sale.Domain.Model.Commands;
using Pc2_Tipo1.API.Sale.Interfaces.Rest.Resources;

namespace Pc2_Tipo1.API.Sale.Interfaces.Rest.Transform;

/// <summary>
/// Assembler to create a <see cref="CreatePurchaseOrderCommand"/> command from a resource.
/// </summary>
/// <remarks>
/// Created by Daniel Crispin Ramos.
/// </remarks>
public static class CreatePurchaseOrderCommandFromResourceAssembler
{
    /// <summary>
    /// Creates a <see cref="CreatePurchaseOrderCommand"/> command from a <see cref="CreatePurchaseOrderResource"/>.
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreatePurchaseOrderResource"/> resource to create the command from.
    /// </param>
    /// <returns>
    /// The <see cref="CreatePurchaseOrderCommand"/> command created from the resource.
    /// </returns>
    public static CreatePurchaseOrderCommand ToCommandFromResource(CreatePurchaseOrderResource resource)
    {
        return new CreatePurchaseOrderCommand(
            resource.Customer,
            resource.PoNumber,
            resource.FabricId,
            resource.Vendor,
            resource.ShipTo,
            resource.Quantity
        );
    }
}