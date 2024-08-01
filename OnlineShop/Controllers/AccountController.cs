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

            Manager? IsManager = _context.Managers.FirstOrDefault(
                user => user.UserName == UserName && user.Password == Password);

            Customer? IsCustomer = _context.Customers.FirstOrDefault(
               user => user.UserName == UserName && user.Password == Password);

            if (IsCustomer != null)
            {
                //    if(user == null)
                //{
                //        ModelState.AddModelError(key: nameof(UserName), "Not Found");
                //        return View(login);
                //    }

                var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier , IsCustomer.CustomerId.ToString()),
            new(ClaimTypes.Name , IsCustomer.UserName),
            new(ClaimTypes.Name , IsCustomer.UserName)
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    //  IsPersistent = login.RememberMe,
                };

                await HttpContext.SignInAsync(principal, properties);
                return RedirectToAction(actionName: "Index", controllerName: "Products", new
                {
                    area = "Customers"
                });
            }
            else if (IsManager != null)
            {
                var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier , IsManager.ManagerId.ToString()),
            new(ClaimTypes.Name , IsManager.UserName),
            new("FirstName" , IsManager.FirstName),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    //  IsPersistent = login.RememberMe,
                };

                await HttpContext.SignInAsync(principal, properties);
                return RedirectToAction(actionName: "Index", controllerName: "Products", new
                {
                    area = "Managers"
                });
            }
            return RedirectToAction(actionName: "Login", controllerName: "Account");
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
