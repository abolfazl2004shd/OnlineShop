using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Data.Services;

namespace OnlineShop.Areas.Admin.Pages
{
    [Authorize]
    public class DisplayCustomersModel(ICustomerService customerService) : PageModel
    {
        public List<User> Customers { get; set; }
        private readonly ICustomerService _customerService = customerService;
        public void OnGet()
        {
            Customers = _customerService.AllCustomers();
        }
        public void OnPost()
        {

        }
    }
}
