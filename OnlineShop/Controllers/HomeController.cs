using OnlineShop.Data.Services;

namespace OnlineShop.Controllers
{
    public class HomeController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;

        [HttpGet]

        #region Show All Products
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(viewName: nameof(Index), model: products);
        }
        #endregion

        #region Product Details
        public IActionResult Details(int? id)
        {
            var product = _productService.GetProductById(id.Value);
            return View(viewName: nameof(Details), model: product);
        }
        #endregion

    }
}
