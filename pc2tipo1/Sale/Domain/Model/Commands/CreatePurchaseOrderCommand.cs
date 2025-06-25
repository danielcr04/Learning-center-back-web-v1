namespace Pc2_Tipo1.API.Sale.Domain.Model.Commands;

public record CreatePurchaseOrderCommand(
    string Customer,
    string PoNumber,
    string? FabricId,
    string Vendor,
    string ShipTo,
    int Quantity
);