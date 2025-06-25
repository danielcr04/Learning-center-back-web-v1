using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Pc2_Tipo1.API.Sale.Domain.Services;
using Pc2_Tipo1.API.Sale.Interfaces.Rest.Resources;
using Pc2_Tipo1.API.Sale.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace Pc2_Tipo1.API.Sale.Interfaces.Rest.Controller;

/// <summary>
/// RESTful controller for managing purchase orders.
/// </summary>
/// <remarks>
/// Created by Daniel Crispin Ramos.
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Endpoints for managing purchase orders.")]
public class PurchaseOrdersController(IPurchaseOrderCommandService purchaseOrderCommandService)
    : ControllerBase
{
    /// <summary>
    /// Creates a new purchase order.
    /// </summary>
    /// <param name="resource">The resource containing the purchase order data to create.</param>
    /// <returns>A newly created purchase order resource with HTTP 201 status, or an error with HTTP 400.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Purchase Order",
        Description = "Creates a new purchase order and returns the created resource.",
        OperationId = "CreatePurchaseOrder")]
    [SwaggerResponse(201, "The purchase order was successfully created.", typeof(PurchaseOrderResource))]
    [SwaggerResponse(400, "The purchase order could not be created due to validation errors.")]
    public async Task<IActionResult> CreatePurchaseOrder(CreatePurchaseOrderResource resource)
    {
        var createPurchaseOrderCommand = CreatePurchaseOrderCommandFromResourceAssembler.ToCommandFromResource(resource);

        var purchaseOrder = await purchaseOrderCommandService.Handle(createPurchaseOrderCommand);
        if (purchaseOrder is null)
            return BadRequest("Failed to create purchase order. Check business rules and input data.");

        var resourceResponse = PurchaseOrderResourceFromEntityAssembler.ToResourceFromEntity(purchaseOrder);

        return CreatedAtAction(nameof(CreatePurchaseOrder), new { purchaseOrder.Id }, resourceResponse);
    }
}