using OnlineShop.Data.Services;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Area(areaName: "Customer")]
    public class AccountController(IAccountService accountService) : Controller
    {
        private readonly IAccountService accountService = accountService;

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View(viewName: "Register");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (register.Password != register.ConfirmedPassword)
            {
                ModelState.AddModelError(key: nameof(register.ConfirmedPassword), "not equal");
                return View(register);
            }

            bool status = accountService.RegisterCustomer(register);

            if (!ModelState.IsValid || !status)
            {
                return View(register);
            }



            return RedirectToAction(actionName: "Login", controllerName: "Account", new
            {
                area = ""
            });
        }

        #endregion
    }
}
