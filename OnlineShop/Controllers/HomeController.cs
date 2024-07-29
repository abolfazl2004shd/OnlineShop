

namespace OnlineShop.Controllers
{
    public class HomeController(OnlineShopDbContext context) : Controller
    {
        private OnlineShopDbContext _context = context;

        [HttpGet]

        #region Show All Products

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Branch)
                .ThenInclude(p => p.Shop)
                .ToListAsync();
            return View(viewName: nameof(Index), model: products);
        }
        #endregion

    }
}
