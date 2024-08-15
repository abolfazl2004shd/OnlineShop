using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Areas.Admin.Pages
{
    [Authorize]
    public class DeleteCustomerModel(ICustomerService customerService) : PageModel
    {
        private readonly ICustomerService _customerService = customerService;


        [BindProperty]
        public User Customer { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _customerService.GetCustomerById(id.Value);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _customerService.GetCustomerById(id.Value);

            if (Customer == null)
            {
                return NotFound();
            }

            _customerService.RemoveCustomer(Customer);
            return RedirectToPage("/DisplayCustomers");
        }
    }
}
