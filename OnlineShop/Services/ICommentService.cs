namespace OnlineShop.Services
{
    public interface ICommentService
    {
        List<Comment> GetProductComments(int id);
    }
}
