using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Pages
{
    public class AddProductModel(IProductService productService) : PageModel
    {
        private readonly IProductService _productService = productService;
        [BindProperty]
        public Models.Product Product { get; set; }
        public void OnGet()
        {
            Product = new()
            {
                CreatedDate = DateTime.Now,
            };
        }

        public IActionResult OnPost(Models.Product product)
        {
            if (!ModelState.IsValid)
                return Page();

            _productService.AddProduct(product);
            return RedirectToPage("/Product/Index");
        }
    }
}
