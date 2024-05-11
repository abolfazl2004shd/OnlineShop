namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customers")]
    public class OrdersController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;


        #region Show All Orders

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.Basket)
                .ThenInclude(o => o.Items)
                .ThenInclude(o => o.Product)
                .ToListAsync();
            return View(viewName: nameof(Index), model: orders);
        }
        #endregion


        #region Show Order In Detailed

        [HttpGet]
        public async Task<IActionResult> Details(int? orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Basket)
                .ThenInclude(o => o.Items)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            return View(viewName: nameof(Details), model: order);
        }
        #endregion
    }
}