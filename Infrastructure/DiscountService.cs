using Application.Commands;
using Application.Interfaces;
using Application.Responses;
using Domain.Enums;

namespace Infrastructure;

public class DiscountService : IDiscountService
{
    public DiscountResponse CheckDiscount(CheckDiscountCommand command)
    {
        decimal discount = 0;

        if (command.MembershipStatus == MembershipStatus.Gold)
            discount = 0.20m;

        if (command.ProductType == ProductType.Electronic && command.ProductPrice > 1000)
            discount = Math.Max(discount, 0.10m);

        if (command.ProductType == ProductType.Book)
            discount = 0;

        var discountedPrice = command.ProductPrice * (1 - discount);

        return new DiscountResponse
        {
            OriginalPrice = command.ProductPrice,
            DiscountedPrice = Math.Round(discountedPrice, 2)
        };
    }
}
