using OnlineShop.Data.Context;

namespace OnlineShop.Data.Services
{
    public class OrderService(OnlineShopDbContext context) : IOrderService
    {
        private readonly OnlineShopDbContext _context = context;

        public List<Order> AllOrders()
        {
            var orders = _context.Orders
                 .Include(o => o.Basket)
                 .ThenInclude(o => o.Customer)
                 .ToList();
            return orders;
        }

        public List<Order> GetAllCustomerOrders(int customerId)
        {
            var orders = _context.Orders
                .Include(o => o.Basket)
                .ThenInclude(o => o.Items)
                .ThenInclude(o => o.Product)
                .Where(o => o.Basket.CustomerId == customerId)
                .ToList();
            return orders;
        }

        public Basket GetBaksetById(int id)
        {
            var basket = _context.Baskets
            .Include(b => b.Items)
            .ThenInclude(b => b.Product)
            .Where(b => b.BasketId == id)
            .FirstOrDefault();
            return basket;
        }

        public Order GetOrderById(int id)
        {
            var order = _context.Orders
               .Include(o => o.Basket)
               .ThenInclude(o => o.Items)
               .ThenInclude(o => o.Product)
               .Where(o => o.OrderId == id)
               .FirstOrDefault();
            return order;
        }
    }
}
