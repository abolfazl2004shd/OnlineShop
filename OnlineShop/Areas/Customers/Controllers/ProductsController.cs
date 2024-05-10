namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customers")]
    public class ProductsController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = _context.Products.Include(p => p.Branch.Shop);
            return View(await products.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Branch)
                .FirstOrDefaultAsync(product => product.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(viewName: "Details", model: product);
        }
    }
}