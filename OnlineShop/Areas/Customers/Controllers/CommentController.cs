using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using System.Diagnostics;

namespace OnlineShop.Areas.Customers.Controllers
{
    [Area(areaName: "Customers")]
    public class CommentController(ICommentService commentService) : Controller
    {
        private readonly ICommentService _commentService = commentService;


        public IActionResult AddComment(int id, string description)
        {
            int customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            _commentService.AddComment(id, customerId, description);
            return RedirectToAction(actionName: "Details", controllerName: "Products", new
            {
                area = "Customers",
                id,
            });
        }
    }
}
