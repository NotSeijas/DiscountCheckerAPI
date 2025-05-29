using Application.Commands;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    /// <summary>
    /// Verifica si se aplica un descuento según el estado de membresía y tipo de producto.
    /// </summary>
    /// <param name="command">Datos del producto y membresía</param>
    /// <returns>Precio original y precio con descuento (si corresponde)</returns>
    [HttpPost("check")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult CheckDiscount([FromBody] CheckDiscountCommand command)
    {
        var result = _discountService.CheckDiscount(command);
        return Ok(result);
    }

    /// <summary>
    /// Obtiene los estados de membresía disponibles.
    /// </summary>
    /// <returns>Lista de estados de membresía</returns>
    [HttpGet("membership/status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetMembershipStatuses()
    {
        var statuses = Enum.GetNames(typeof(Domain.Enums.MembershipStatus));
        return Ok(statuses);
    }

    /// <summary>
    /// Obtiene los tipos de producto disponibles.
    /// </summary>
    /// <returns>Lista de tipos de producto</returns>
    [HttpGet("product/types")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetProductTypes()
    {
        var types = Enum.GetNames(typeof(Domain.Enums.ProductType));
        return Ok(types);
    }
}
