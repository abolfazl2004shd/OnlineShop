using OnlineShop.Data.Context;

namespace OnlineShop.Data.Services
{
    public class CustomerService(OnlineShopDbContext context) : ICustomerService
    {
        private readonly OnlineShopDbContext _context = context;
        public List<Customer> AllCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }

        public bool RemoveCustomer(int id)
        {
            var customer = GetCustomerById(id);

            try
            {
                _context.Customers.Remove(customer);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
