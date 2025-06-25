namespace Pc2_Tipo1.API.Sale.Interfaces.Rest.Resources;

/// <summary>
/// Purchase Order resource for REST API responses.
/// </summary>
/// <param name="Id">
/// The unique identifier of the purchase order.
/// </param>
/// <param name="Customer">
/// The name of the customer that placed the order.
/// </param>
/// <param name="PoNumber">
/// The purchase order number provided by the customer.
/// </param>
/// <param name="FabricId">
/// The ID of the fabric associated with the order.
/// </param>
/// <param name="Vendor">
/// The name of the vendor fulfilling the order.
/// </param>
/// <param name="ShipTo">
/// The destination address for the order.
/// </param>
/// <param name="Quantity">
/// The quantity of items in the order.
/// </param>
/// <remarks>
/// Created by Daniel Crispin Ramos.
/// </remarks>
public record PurchaseOrderResource(
    int Id,
    string Customer,
    string PoNumber,
    int FabricId,   
    string Vendor,
    string ShipTo,
    int Quantity
);