namespace OnlineShop.Data.Services
{
    public interface ICustomerService
    {
        List<Customer> AllCustomers();
        Customer GetCustomerById(int id);
        bool RemoveCustomer(int id);
    }
}
