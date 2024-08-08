using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Pages.Product
{
    public class AddModel(IProductService productService) : PageModel
    {
        private readonly IProductService _productService = productService;
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
            
            _productService.AddProduct(product);
            return RedirectToPage("/Product/Index");
        }
    }
}
