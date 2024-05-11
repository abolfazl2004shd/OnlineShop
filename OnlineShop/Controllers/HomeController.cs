namespace OnlineShop.Controllers
{
    public class HomeController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        [HttpGet]

        #region Show All Products

        public async Task<IActionResult> Index()
        {
            var AllProducts = await _context.Products.ToListAsync();
            return View(AllProducts);
        }
        #endregion

    }
}
