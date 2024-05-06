namespace OnlineShop.Controllers
{
    public class AccountController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            string UserName = login.UserName;
            string Password = login.Password;

            var user = _context.Customers.SingleOrDefault(
                user => user.UserName == UserName && user.Password == Password);

            if (user == null)
            {
                ModelState.AddModelError(key: nameof(UserName), "Not Found");
                return View(login);
            }

            var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier , user.CustomerId.ToString()),
            new(ClaimTypes.Name , user.UserName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                //  IsPersistent = login.RememberMe,
            };

            await HttpContext.SignInAsync(principal, properties);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        #endregion


        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
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
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        #endregion

        #region Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(actionName: "Login", controllerName: "Account");
        }
        #endregion
    }
}
