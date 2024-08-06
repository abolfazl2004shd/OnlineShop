namespace OnlineShop.Models
{
    [Table(name: "Baskets")]
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

        public decimal GetFinalDiscount()
        {
            decimal initialPrice = Items.Sum(item => item.Product.GetDiscount() * item.Quantity);
            return initialPrice.FormatDecimal();
        }
        public decimal GetInitialPrice()
        {
            decimal discount = Items.Sum(item => item.Product.Price * item.Quantity);
            return discount.FormatDecimal();
        }
        public decimal GetTax(int Coefficient)
        {
            decimal tax = (GetInitialPrice() - GetFinalDiscount()) * Coefficient / 100;
            return tax.FormatDecimal();
        }
        public decimal GetFinalPrice()
        {
            decimal finalPrice = GetInitialPrice() - GetFinalDiscount() + GetTax(9);
            return finalPrice.FormatDecimal();
        }
    }
}
