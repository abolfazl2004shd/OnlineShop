namespace OnlineShop.Areas.Managers.Controllers
{
    [Area(areaName: "Managers")]
    public class AccountController(OnlineShopDbContext _db) : Controller
    {
        private readonly OnlineShopDbContext _context = _db;

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
            Manager manager = new()
            {
                UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName,
                PhoneNumber = register.PhoneNumber,
                EmailAddress = register.EmailAddress,
                SSN = register.SSN,
                Sex = register.Sex,
                RegistrationDate = DateTime.Now,
                Password = register.Password,
            };

            _context.Entry(manager).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "Index", controllerName: "Home", new
            {
                area = "Managers"
            });
        }

        #endregion
    }
}
