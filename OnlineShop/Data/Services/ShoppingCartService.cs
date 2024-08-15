using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;

namespace OnlineShop.Data.Services
{
    public class ShoppingCartService(OnlineShopDbContext context) : IShoppingCartService
    {
        private readonly OnlineShopDbContext _context = context;
        public void AddToCart(int productId, int customerId)
        {
            User? customer = _context.Users.Find(customerId);
            Product? product = _context.Products.Find(productId);


            Basket? basket = _context.Baskets.Where(b => b.CustomerId == customerId && !b.IsFinalize).FirstOrDefault();

            if (basket == null)
            {
                basket = new()
                {
                    IsFinalize = false,
                    CustomerId = customerId,
                };
                _context.Entry(basket).State = EntityState.Added;
                _context.SaveChanges();
                Item item = new()
                {
                    ProductId = productId,
                    Quantity = 1,
                    BasketId = basket.BasketId,
                };
                _context.Entry(item).State = EntityState.Added;
            }
            else
            {
                Item? item = _context.Items.Where(b => b.BasketId == basket.BasketId && b.ProductId == productId).FirstOrDefault();

                if (item == null)
                {
                    item = new()
                    {
                        ProductId = productId,
                        Quantity = 1,
                        BasketId = basket.BasketId,
                    };
                    _context.Entry(item).State = EntityState.Added;
                }
                else
                {
                    item.Quantity++;
                }
            }

            _context.SaveChanges();
        }


        public Basket DisplayCart(int customerId)
        {
            Basket? basket = _context.Baskets
                 .Include(b => b.Items)
                 .ThenInclude(b => b.Product)
                 .FirstOrDefault(b => b.CustomerId == customerId && !b.IsFinalize);
            return basket;
        }

        public void RemoveFromCart(int itemId)
        {
            Item? item = _context.Items.FirstOrDefault(item => item.ItemId == itemId);
            if (item == null)
            {

            }
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public void Checkout(AddressViewModel address, int customerId)
        {
            Basket? basket = _context.Baskets
                          .Include(b => b.Items)
                          .ThenInclude(b => b.Product)
                          .First(b => b.CustomerId == customerId && !b.IsFinalize);


            foreach (var item in basket.Items)
            {
                _context.Products
                    .Where(o => o.ProductId == item.ProductId)
                    .First().Amount -= item.Quantity;
            }

            Order order = new()
            {
                BasketId = basket.BasketId,
                RegistrationDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(3),
                PostalCode = address.PostalCode,
                City = address.City,
                Street = address.Street,
                Plaque = address.Plaque,
                ShippingPrice = 25,
            };
            _context.Entry(basket).State = EntityState.Modified;
            _context.Orders.Entry(order).State = EntityState.Added;
            _context.SaveChanges();
            _context.Users.Find(customerId).Wallet -= order.GetFinalPrice();
            basket.IsFinalize = true;
            _context.SaveChanges();
        }

    }
}
