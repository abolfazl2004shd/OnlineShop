namespace OnlineShop.Data.Services
{
    public interface ICustomerService
    {
        List<User> AllCustomers();
        User GetCustomerById(int id);
        bool RemoveCustomer(int id);
        bool RemoveCustomer(User customer);
    }
}
