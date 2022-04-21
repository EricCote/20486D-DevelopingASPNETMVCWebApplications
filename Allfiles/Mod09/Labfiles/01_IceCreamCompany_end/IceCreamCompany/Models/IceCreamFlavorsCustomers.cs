namespace IceCreamCompany.Models;

public class IceCreamFlavorsCustomers
{
    public int IceCreamId { get; set; }
    public IceCream IceCream { get; set; } = null!;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}
