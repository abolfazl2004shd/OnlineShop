using OnlineShop.Services;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customer")]
    public class ProductController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;


        #region Show All Products

        [HttpGet]
        [AllowAnonymous]
        [Route("/Product")]
        public IActionResult Index()
        {
            return View(viewName: nameof(Index), model: _productService.GetAllProducts());
        }
        #endregion


        #region Show Product in Detailed

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var product = _productService.GetProductById(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            if (product == null)
            {
                return NotFound();
            }
            return View(viewName: nameof(Details), model: product);
        }
        #endregion
    }
}