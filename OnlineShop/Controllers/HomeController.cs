namespace OnlineShop.Controllers
{
    public class HomeController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShowAllProducts()
        {
            var AllProducts = await _context.Products.ToListAsync();
            return View(AllProducts);
        }

        // int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        // Customer? customer = _context.Customers.Find(customerId);
    }
}
