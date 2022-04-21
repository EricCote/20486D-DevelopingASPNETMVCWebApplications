using ProductsWebsite.Models;

namespace ProductsWebsite.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
}

