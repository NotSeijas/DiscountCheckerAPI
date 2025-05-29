using Domain.Enums;

namespace Application.Commands;

public class CheckDiscountCommand
{
    public MembershipStatus MembershipStatus { get; set; }
    public ProductType ProductType { get; set; }
    public decimal ProductPrice { get; set; }
}
