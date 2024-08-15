using OnlineShop.Data.Context;

namespace OnlineShop.Data.Services
{
    public class CustomerService(OnlineShopDbContext context) : ICustomerService
    {
        private readonly OnlineShopDbContext _context = context;
        public List<User> AllCustomers()
        {
            var customers = _context.Users
                .Where(c => c.Role == "customer")
                .ToList();
            return customers;
        }

        public User GetCustomerById(int id)
        {
            var customer = _context.Users.FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }

        public bool RemoveCustomer(int id)
        {
            var customer = GetCustomerById(id);

            try
            {
                _context.Users.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool RemoveCustomer(User customer)
        {
            try
            {
                _context.Users.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
