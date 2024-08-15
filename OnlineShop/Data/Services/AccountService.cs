using OnlineShop.Data.Context;

namespace OnlineShop.Data.Services
{
    public class AccountService(OnlineShopDbContext context) : IAccountService
    {
        private readonly OnlineShopDbContext _context = context;



        public bool RegisterCustomer(RegisterViewModel register)
        {
            try
            {
                Customer customer = new()
                {
                    UserName = register.UserName,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    PhoneNumber = register.PhoneNumber,
                    EmailAddress = register.EmailAddress,
                    SSN = register.SSN,
                    Gender = register.Gender,
                    RegistrationDate = DateTime.Now,
                    Wallet = 1000,
                    Password = register.Password,
                };

                _context.Entry(customer).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //bool IAccountService.LoginCustomer(LoginViewModel login)
        //{

        //}

    }
}
