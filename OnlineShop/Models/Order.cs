namespace OnlineShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int BasketId { get; set; }

        [Required]
        public required string PostalCode { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public decimal ShippingPrice { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string Plaque { get; set; }



        [ForeignKey(nameof(BasketId))]
        [Required]
        public Basket Basket { get; set; }

        public decimal GetFinalPrice()
        {
            decimal finalPrice = Basket.GetFinalPrice() + ShippingPrice;
            return finalPrice;
        }
        public string GetAddress()
        {
            string address = $"{City} City, {Street} Street, {Plaque} Plaque";
            return address;
        }
    }
}
