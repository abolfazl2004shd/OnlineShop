namespace OnlineShop.Services
{
    public interface ICommentService
    {
        List<Comment> GetProductComments(int id);
        void AddComment(int productId, int customerId, string description);
     //   bool HasProductPurchased(int customerId, int productId);
    }
}
