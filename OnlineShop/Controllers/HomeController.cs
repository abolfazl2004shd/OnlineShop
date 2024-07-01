namespace OnlineShop.Controllers
{
    public class HomeController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        [HttpGet]

        #region Show All Products

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
               .Include(p => p.Branch.Shop)
               .Where(p => p.Amount > 0)
               .ToListAsync();
            return View(viewName: nameof(Index), model: products);
        }
        #endregion

    }
}
