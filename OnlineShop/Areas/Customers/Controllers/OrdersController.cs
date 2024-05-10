namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customers")]
    public class OrdersController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            return View(viewName: "Index", model: orders);
        }
    }
}