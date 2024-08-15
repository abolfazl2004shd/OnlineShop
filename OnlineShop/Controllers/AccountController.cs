using OnlineShop.Data.Context;

namespace OnlineShop.Controllers
{
    public class AccountController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View(viewName: nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            string UserName = login.UserName;
            string Password = login.Password;

            User? user = _context.Users.FirstOrDefault(
               user => user.UserName == UserName && user.Password == Password);

            if (user != null)
            {
                if (user == null)
                {
                    ModelState.AddModelError(key: nameof(UserName), "Not Found");
                    return View(login);
                }

                var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier , user.CustomerId.ToString()),
            new(ClaimTypes.Name , user.UserName),
            new(ClaimTypes.Name , user.UserName)
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    //  IsPersistent = login.RememberMe,
                };

                await HttpContext.SignInAsync(principal, properties);

                if (user.Role.Equals("admin", StringComparison.CurrentCultureIgnoreCase))
                {
                    return RedirectToPage(pageName: "/Dashboard", new
                    {
                        area = "Admin"
                    });
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Product", new
                    {
                        area = "Customer"
                    });
                }

            }

            return RedirectToAction(actionName: nameof(Login), controllerName: "Account");
        }
        #endregion


        #region Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(actionName: "Index", controllerName: "Home", new
            {
                area = "",
            });
        }
        #endregion
    }
}
