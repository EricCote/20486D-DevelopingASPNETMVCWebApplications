namespace ElectricStore.Models;

public class SessionStateViewModel
{
    public string CustomerName { get; set; } = null!;
    public List<Product> SelectedProducts { get; set; } = null!;
}
