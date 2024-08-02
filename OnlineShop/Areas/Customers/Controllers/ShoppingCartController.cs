using OnlineShop.Services;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Authorize]
    [Area(areaName: "Customers")]
    public class ShoppingCartController(IShoppingCartService shoppingCartService) : Controller
    {
        private readonly IShoppingCartService _shoppingCartService = shoppingCartService;

        #region Insert Item To Cart

        [HttpGet]
        public async Task<IActionResult> AddToCart(int? id)
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            //Customer? customer = await _context.Customers.FindAsync(customerId);
            // Product? product = await _context.Products.FindAsync(id);
            //if (product == null)
            //{
            //    return RedirectToAction(actionName: "Index", controllerName: "Products", new
            //    {
            //        area = "Customers"
            //    });
            //}

            //Basket? basket = await _context.Baskets.Where(b => b.CustomerId == customerId && !b.IsFinalize).FirstOrDefaultAsync();

            //if (basket == null)
            //{
            //    basket = new()
            //    {
            //        IsFinalize = false,
            //        CustomerId = customerId,
            //    };
            //    _context.Entry(basket).State = EntityState.Added;
            //    await _context.SaveChangesAsync();
            //    Item item = new()
            //    {
            //        ProductId = id.Value,
            //        Quantity = 1,
            //        BasketId = basket.BasketId,
            //    };
            //    _context.Entry(item).State = EntityState.Added;
            //}
            //else
            //{
            //    Item? item = await _context.Items.Where(b => b.BasketId == basket.BasketId && b.ProductId == id.Value).FirstOrDefaultAsync();

            //    if (item == null)
            //    {
            //        item = new()
            //        {
            //            ProductId = id.Value,
            //            Quantity = 1,
            //            BasketId = basket.BasketId,
            //        };
            //        _context.Entry(item).State = EntityState.Added;
            //    }
            //    else
            //    {
            //        item.Quantity++;
            //    }
            //}
            _shoppingCartService.AddToCart(id.Value, customerId);
            //await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "Index", controllerName: "Products", new
            {
                area = "Customers"
            });
        }
        #endregion


        #region Display Shopping Cart

        [HttpGet]
        [Route("/Cart")]
        public async Task<IActionResult> Cart()
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var basket = _shoppingCartService.DisplayCart(customerId);

            return View(viewName: "Cart", model: basket);
        }
        #endregion


        #region Remove Item From Cart

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int? itemId)
        {
            _shoppingCartService.RemoveFromCart(itemId.Value);
            return RedirectToAction(actionName: "Cart", controllerName: "ShoppingCart", new
            {
                area = "Customers"
            });
        }
        #endregion


        #region Checkout

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(viewName: nameof(Checkout));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([Bind("City", "Street", "Plaque", "PostalCode")] AddressViewModel address)
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            _shoppingCartService.Checkout(address, customerId);

            return RedirectToAction(actionName: nameof(Index), controllerName: "Products", new
            {
                area = "Customers"
            });
        }
        #endregion
    }
}