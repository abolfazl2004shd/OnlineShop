
namespace OnlineShop.Services
{
    public class CommentService : ICommentService
    {
        private OnlineShopDbContext _context;

        public CommentService(OnlineShopDbContext context)
        {
            _context = context;
        }
        public List<Comment> GetProductComments(int id)
        {
            var comments = _context.Comments.Where(c => c.ProductId == id).ToList();
            return comments;
        }
    }
}
