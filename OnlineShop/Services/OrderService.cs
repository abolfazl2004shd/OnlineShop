﻿using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class OrderService(OnlineShopDbContext context) : IOrderService
    {
        private readonly OnlineShopDbContext _context = context;
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