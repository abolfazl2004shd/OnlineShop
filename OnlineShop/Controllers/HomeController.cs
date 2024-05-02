namespace OnlineShop.Controllers
{
    public class HomeController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowAllProducts()
        {
            var AllProducts = _context.Products.ToList();
            return View(AllProducts);
        }
    }
}
