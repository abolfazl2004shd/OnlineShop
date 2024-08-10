using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Pages
{
    public class DisplayCustomersModel(ICustomerService customerService) : PageModel
    {
        public List<Models.Customer> Customers { get; set; }
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
