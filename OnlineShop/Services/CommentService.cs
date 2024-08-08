
namespace OnlineShop.Services
{
    public class CommentService(OnlineShopDbContext context) : ICommentService
    {
        private readonly OnlineShopDbContext _context = context;

        public void AddComment(int productId, int customerId, string description)
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
            var comments = _context.Comments
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .Where(c => c.ProductId == id).ToList();
            return comments;
        }

        //public bool HasProductPurchased(int customerId, int productId)
        //{
        //   var status = _context.Baskets
        //        .Include(b =>b.Items)
        //        .Where(b => b.CustomerId == customerId && b.)
        //        }
    }
}
