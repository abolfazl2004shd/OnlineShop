using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Data.Services;

namespace OnlineShop.Areas.Admin.Pages
{
    [Authorize]
    public class DiplayProductsModel(IProductService productService) : PageModel
    {
        private readonly IProductService _productService = productService;
        public List<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productService.GetAllProducts();
        }
    }
}
