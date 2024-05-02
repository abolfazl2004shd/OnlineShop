using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineShop.Controllers
{
    public class AccountController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
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
                IsPersistent = login.RememberMe,
            };
            HttpContext.SignInAsync(principal, properties);
            return View("Home/Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
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
                Sex = register.Sex,
                SSN = register.SSN,
                RegistrationDate = DateTime.Now,
                EmailAddress = register.EmailAddress,
                Password = register.Password,
            };

            _context.Entry(customer).State = EntityState.Added;
            _context.SaveChanges();
            return Redirect("/Home/Index");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Account/Login");
        }
    }
}
