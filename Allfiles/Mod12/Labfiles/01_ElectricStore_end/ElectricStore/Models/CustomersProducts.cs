namespace ElectricStore.Models;

public class CustomersProducts
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}
