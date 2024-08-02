
namespace OnlineShop.Services
{
    public class CommentService(OnlineShopDbContext context) : ICommentService
    {
        private OnlineShopDbContext _context = context;

        public void AddComment(int productId , int customerId , string description)
        {
            var commment = new Comment()
            {
                CreatedDate = DateTime.Now,
                Description = description,
                ProductId = productId,
                CustomerId = customerId,
            };
            _context.Comments.Add(commment);
            _context.SaveChanges();
        }

        public List<Comment> GetProductComments(int id)
        {
            var comments = _context.Comments.Where(c => c.ProductId == id).ToList();
            return comments;
        }
    }
}
