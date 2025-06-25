using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Pc2_Tipo1.API.Sale.Domain.Model.Aggregates;


/// <summary>
/// Audit fields for PurchaseOrder
/// </summary>
/// <remarks>
/// Author: Daniel Crispin Ramos
/// </remarks>
public partial class PurchaseOrder : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}