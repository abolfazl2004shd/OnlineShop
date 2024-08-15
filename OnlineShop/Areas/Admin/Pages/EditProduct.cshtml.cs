using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Areas.Admin.Pages
{
    [Authorize]
    public class EditProductModel : PageModel
    {
        private readonly IProductService _productService;

        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productService.GetProductById(id.Value);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Product == null)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(Product);

            return RedirectToPage("/DisplayProducts");
        }
    }
}