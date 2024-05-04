namespace OnlineShop.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public int BasketId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }


        [ForeignKey(nameof(ProductId))]
        [Required]
        public required Product Product { get; set; }

        [ForeignKey(nameof(BasketId))]
        [Required]
        public required Basket Basket { get; set; }
    }
}
