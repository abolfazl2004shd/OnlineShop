namespace OnlineShop.Services
{
    public interface IShoppingCartService
    {
        void AddToCart(int productId , int customerId);
        Basket DisplayCart(int customerId);
        void RemoveFromCart(int itemId);
        void Checkout(AddressViewModel address , int customerId);
    }
}
