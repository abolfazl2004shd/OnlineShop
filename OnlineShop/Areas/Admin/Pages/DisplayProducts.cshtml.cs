using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Pages
{
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
