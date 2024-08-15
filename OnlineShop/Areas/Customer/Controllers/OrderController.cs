using OnlineShop.Data.Services;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customer")]
    public class OrderController(IOrderService orderService) : Controller
    {
        private readonly IOrderService _orderService = orderService;

        #region Show All Orders

        [HttpGet]
        //[Route("/Order")]
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
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderById(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(viewName: nameof(Details), model: order);
        }

        #endregion
    }
}