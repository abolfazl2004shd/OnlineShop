namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customers")]
    public class ProductsController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        #region Show All Products

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Branch.Shop)
                .Where(p => p.Amount > 0)
                .ToListAsync();
            return View(viewName: nameof(Index), model: products);
        }
        #endregion


        #region Show Product in Detailed

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
            return View(viewName: nameof(Details), model: product);
        }
        #endregion
    }
}