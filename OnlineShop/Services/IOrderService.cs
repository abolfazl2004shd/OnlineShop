namespace OnlineShop.Services
{
    public interface IOrderService
    {
        List<Order> GetAllCustomerOrders(int customerId);
        Order GetOrderById(int id);
        Basket GetBaksetById(int id);
    }
}
