using ProductsWebsite.Data;
using ProductsWebsite.Models;

namespace ProductsWebsite.Repositories;

public class ProductRepository : IProductRepository
{
    private ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.Products.ToList();
    }
}
