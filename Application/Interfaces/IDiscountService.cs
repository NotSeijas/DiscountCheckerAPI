using Application.Commands;
using Application.Responses;

namespace Application.Interfaces;

public interface IDiscountService
{
    DiscountResponse CheckDiscount(CheckDiscountCommand command);
}
