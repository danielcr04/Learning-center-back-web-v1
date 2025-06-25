using Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;
using Pc2_Tipo1.API.Sale.Domain.Model.Commands;
using Pc2_Tipo1.API.Sale.Domain.Repositories;
using Pc2_Tipo1.API.Sale.Domain.Services;
using Pc2_Tipo1.API.Shared.Domain.Repositories;

namespace Pc2_Tipo1.API.Sale.Application.Internal.CommandServices;

/// <summary>
///     Represents the purchase order command service in the Hialpesa Production Platform.
/// </summary>
/// <param name="purchaseOrderRepository">
///     The <see cref="IPurchaseOrderRepository" /> to use for persistence.
/// </param>
/// <param name="unitOfWork">
///     The <see cref="IUnitOfWork" /> to use for transaction control.
/// </param>
public class PurchaseOrderCommandService(
    IPurchaseOrderRepository purchaseOrderRepository,
    IUnitOfWork unitOfWork)
    : IPurchaseOrderCommandService
{
    /// <inheritdoc />
    public async Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command)
    {
        try
        {
            var exists = await purchaseOrderRepository.ExistsPurchaseOrderByCustomerAndPoNumber(
                command.Customer, command.PoNumber);

            if (exists)
                throw new ArgumentException($"A purchase order for customer '{command.Customer}' with PO Number '{command.PoNumber}' already exists.");

            var purchaseOrder = new PurchaseOrder(command);

            await purchaseOrderRepository.AddAsync(purchaseOrder);
            await unitOfWork.CompleteAsync();

            return purchaseOrder;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}