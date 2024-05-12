namespace OnlineShop.Areas.Customers.Controllers
{
    [Area(areaName: "Customers")]
    public class AccountController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View(viewName: "Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (register.Password != register.ConfirmedPassword)
            {
                ModelState.AddModelError(key: nameof(register.ConfirmedPassword), "not equal");
                return View(register);
            }
            Customer customer = new()
            {
                UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName,
                PhoneNumber = register.PhoneNumber,
                EmailAddress = register.EmailAddress,
                SSN = register.SSN,
                Sex = register.Sex,
                RegistrationDate = DateTime.Now,
                Wallet = 1000,
                Password = register.Password,
            };

            _context.Entry(customer).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "Login", controllerName: "Account", new
            {
                area = ""
            });
        }

        #endregion
    }
}
