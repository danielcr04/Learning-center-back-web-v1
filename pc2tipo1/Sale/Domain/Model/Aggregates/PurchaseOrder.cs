using Pc2_Tipo1.API.Sale.Domain.Model.Commands;
using Pc2_Tipo1.API.Sale.Domain.Model.ValueObjects;

namespace Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;

public partial class PurchaseOrder
{
        public int Id {get; private set;  }
        public string Customer {get; private set;}
        public string PoNumber {get; private set;}
        public int FabricId {get; private set;}
        public string Vendor  {get; private set;}
        public string ShipTo {get; private set;}
        public int Quantity {get; private set;}
        
        public PurchaseOrder(CreatePurchaseOrderCommand command)
        {
                ValidateBusinessRules(command);
                var fabric = string.IsNullOrWhiteSpace(command.FabricId)
                        ? EFabric.GetDefault() : EFabric.FromName(command.FabricId!);
                Customer = command.Customer;
                PoNumber = command.PoNumber;
                FabricId = fabric.Id;
                Vendor = command.Vendor;
                ShipTo = command.ShipTo;
                Quantity = command.Quantity;
        }
        
        public PurchaseOrder() { }

        private static void ValidateBusinessRules(CreatePurchaseOrderCommand command)
        {
                // Validate customer
                if (string.IsNullOrWhiteSpace(command.Customer))
                        throw new ArgumentException("Customer cannot be null or empty");
        
                if (command.Customer.Length < 4 || command.Customer.Length > 50)
                        throw new ArgumentException("Customer must be between 4 and 50 characters");

                // Validate vendor
                if (string.IsNullOrWhiteSpace(command.Vendor))
                        throw new ArgumentException("Vendor cannot be null or empty");
        
                if (command.Vendor.Length < 4 || command.Vendor.Length > 50)
                        throw new ArgumentException("Vendor must be between 4 and 50 characters");

                // Validate PO Number
                if (string.IsNullOrWhiteSpace(command.PoNumber))
                        throw new ArgumentException("PO Number cannot be null or empty");

                // Validate ShipTo
                if (string.IsNullOrWhiteSpace(command.ShipTo))
                        throw new ArgumentException("ShipTo cannot be null or empty");

                // Validate Quantity
                if (command.Quantity <= 0)
                        throw new ArgumentException("Quantity must be greater than 0");

                // Validate FabricId if provided
                if (!string.IsNullOrWhiteSpace(command.FabricId))
                {
                        var fabric = EFabric.FromName(command.FabricId!);
                        if (fabric == null)
                                throw new ArgumentException("Invalid fabric name");
                }
        }
        
        /// <summary>
        /// Gets the fabric information
        /// </summary>
        /// <returns>EFabric instance</returns>
        public EFabric GetFabric()
        {
                return EFabric.FromId(FabricId) ?? EFabric.GetDefault();
        }
}