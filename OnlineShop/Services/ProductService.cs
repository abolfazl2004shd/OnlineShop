
namespace OnlineShop.Services
{
    public class ProductService(OnlineShopDbContext context) : IProductService
    {
        private readonly OnlineShopDbContext _context = context;

        public List<Product> GetAllProducts()
        {
            var products = _context.Products
                  .Include(p => p.Branch.Shop)
                  .Where(p => p.Amount > 0)
                  .ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products
                 .Include(p => p.Branch)
                 .FirstOrDefault(product => product.ProductId == id);
            return product;
        }
    }
}
