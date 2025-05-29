using Domain.Enums;

namespace Domain.Entities;

public class Product
{
    public ProductType ProductType { get; set; }
    public decimal ProductPrice { get; set; }
}
