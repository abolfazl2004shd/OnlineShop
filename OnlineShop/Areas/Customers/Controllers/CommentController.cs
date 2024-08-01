using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Area(areaName: "Customers")]
    public class CommentController : Controller
    {
        private OnlineShopDbContext _context;

        public CommentController(OnlineShopDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddComment(int id, string description)
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var commment = new Comment()
            {
                CreatedDate = DateTime.Now,
                Description = description,
                ProductId = id,
                CustomerId = customerId,
            };
            _context.Comments.Add(commment);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Details", controllerName: "Products", new
            {
                area = "Customers",
                 id,
            });
        }
    }
}
