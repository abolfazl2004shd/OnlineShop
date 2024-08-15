using OnlineShop.Data.Context;

namespace OnlineShop.Data.Services
{
    public class ProductService(OnlineShopDbContext context) : IProductService
    {
        private readonly OnlineShopDbContext _context = context;

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }


        public List<Product> GetAllProducts()
        {
            var products = _context.Products
                  .Where(p => p.Amount > 0)
                  .ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products
                 .FirstOrDefault(product => product.ProductId == id);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
