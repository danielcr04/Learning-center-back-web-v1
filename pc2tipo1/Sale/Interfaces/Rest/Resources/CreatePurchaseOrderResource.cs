namespace Pc2_Tipo1.API.Sale.Interfaces.Rest.Resources;

/// <summary>
/// Resource for creating a new purchase order.
/// </summary>
/// <param name="Customer">
/// The name of the customer placing the order.
/// </param>
/// <param name="PoNumber">
/// The unique purchase order number defined by the customer.
/// </param>
/// <param name="FabricId">
/// The name of the fabric type (e.g., "Algodon", "Modal"). Optional. Defaults to "Algodon" if not provided.
/// </param>
/// <param name="Vendor">
/// The name of the vendor fulfilling the order.
/// </param>
/// <param name="ShipTo">
/// The shipping destination for the order.
/// </param>
/// <param name="Quantity">
/// The number of items in the purchase order.
/// </param>
/// <remarks>
/// Created by Daniel Crispin Ramos.
/// </remarks>
public record CreatePurchaseOrderResource(
    string Customer,
    string PoNumber,
    string? FabricId,
    string Vendor,
    string ShipTo,
    int Quantity
);