using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Services;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Pages
{
    public class DeleteProductModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteProductModel(IProductService productService)
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

        public IActionResult OnPost(int? id)
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

            _productService.DeleteProduct(Product);
            return RedirectToPage("/DisplayProducts");
        }
    }
}
