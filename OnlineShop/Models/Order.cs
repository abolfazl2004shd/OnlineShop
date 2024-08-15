using OnlineShop.Helper;

namespace OnlineShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int BasketId { get; set; }

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public decimal ShippingPrice { get; set; }

        [Required]
        public  string City { get; set; } = string.Empty;

        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public string Plaque { get; set; } = string.Empty;



        [ForeignKey(nameof(BasketId))]
        [Required]
        public Basket Basket { get; set; }

        public decimal GetFinalPrice()
        {
            decimal finalPrice = Basket.GetFinalPrice() + ShippingPrice;
            return finalPrice.FormatDecimal();
        }
        public string GetAddress()
        {
            string address = $"{City} City, {Street} Street, {Plaque} Plaque";
            return address;
        }
    }
}
