using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Pages.Product
{
    public class IndexModel(IProductService productService) : PageModel
    {
        private readonly IProductService _productService = productService;
        public List<Models.Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productService.GetAllProducts();
        }
    }
}
