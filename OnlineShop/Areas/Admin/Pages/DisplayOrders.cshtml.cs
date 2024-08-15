using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Areas.Admin.Pages
{
    [Authorize]
    public class DisplayOrdersModel(IOrderService orderService) : PageModel
    {
        private readonly IOrderService _orderService = orderService;
        public List<Order> Orders { get; set; }
        public void OnGet()
        {
            Orders = _orderService.AllOrders();
        }
    }
}
