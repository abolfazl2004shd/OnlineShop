namespace OnlineShop.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public bool IsFinalize { get; set; } = false;



        [ForeignKey(nameof(CustomerId))]
        [Required]
        public Customer Customer { get; set; }

        public List<Item> Items { get; set; }
        public Order? Order { get; set; }

        public decimal GetDiscount()
        {
            decimal initialPrice = Items.Sum(item => item.Product.GetDiscount() * item.Quantity);
            return initialPrice;
        }
        public decimal GetInitialPrice()
        {
            decimal discount = Items.Sum(item => item.Product.Price * item.Quantity);
            return discount;
        }
        public decimal GetTax()
        {
            decimal tax = GetInitialPrice() * 9 / 100;
            return tax;
        }
        public decimal GetFinalPrice()
        {
            decimal finalPrice = GetInitialPrice() + GetTax() - GetDiscount();
            return finalPrice;
        }
    }
}
