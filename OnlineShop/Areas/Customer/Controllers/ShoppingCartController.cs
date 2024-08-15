using OnlineShop.Data.Services;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customer")]
    public class ShoppingCartController(IShoppingCartService shoppingCartService) : Controller
    {
        private readonly IShoppingCartService _shoppingCartService = shoppingCartService;

        #region Insert Item To Cart

        [HttpGet]
        public IActionResult AddToCart(int? id)
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());


            _shoppingCartService.AddToCart(id.Value, customerId);

            return RedirectToAction(actionName: "Index", controllerName: "Product", new
            {
                area = "Customer"
            });
        }
        #endregion


        #region Display Shopping Cart

        [HttpGet]
        [Route("/Cart")]
        public IActionResult Cart()
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var basket = _shoppingCartService.DisplayCart(customerId);

            return View(viewName: "Cart", model: basket);
        }
        #endregion


        #region Remove Item From Cart

        [HttpGet]
        public IActionResult RemoveFromCart(int? itemId)
        {
            _shoppingCartService.RemoveFromCart(itemId.Value);
            return RedirectToAction(actionName: "Cart", controllerName: "ShoppingCart", new
            {
                area = "Customer"
            });
        }
        #endregion


        #region Checkout

        [HttpGet]
        public IActionResult Checkout(int? id)
        {
            AddressViewModel address = new()
            {
                BasketId = id.Value,
            };

            return View(viewName: nameof(Checkout) , model:address);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([Bind("City", "Street", "Plaque", "PostalCode")] AddressViewModel address)
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            _shoppingCartService.Checkout(address, customerId);

            return RedirectToAction(actionName: nameof(Index), controllerName: "Product", new
            {
                area = "Customer"
            });
        }
        #endregion
    }
}