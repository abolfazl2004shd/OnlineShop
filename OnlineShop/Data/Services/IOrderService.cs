namespace OnlineShop.Data.Services
{
    public interface IOrderService
    {
        List<Order> GetAllCustomerOrders(int customerId);
        List<Order> AllOrders();
        Order GetOrderById(int id);
        Basket GetBaksetById(int id);
    }
}
