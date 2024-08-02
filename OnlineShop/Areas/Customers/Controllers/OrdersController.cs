using OnlineShop.Services;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customers")]
    public class OrdersController(IOrderService orderService) : Controller
    {
        private readonly IOrderService _orderService = orderService;

        #region Show All Orders

        [HttpGet]
        public IActionResult Index()
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var orders = _orderService.GetAllCustomerOrders(customerId);
            return View(viewName: nameof(Index), model: orders);
        }
        #endregion


        #region Show Order In Detailed

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var order = _orderService.GetOrderById(id.Value);
            return View(viewName: nameof(Details), model: order);
        }
        #endregion
    }
}