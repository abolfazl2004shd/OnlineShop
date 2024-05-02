namespace OnlineShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int BasketId { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public decimal ShippingPrice { get; set; }

        [ForeignKey(nameof(BasketId))]
        [Required]
        public required Basket Basket { get; set; }
    }
}
