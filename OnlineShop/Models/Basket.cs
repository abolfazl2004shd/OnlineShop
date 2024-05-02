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
        public required Customer Customer { get; set; }

        public required List<Item> Items { get; set; }
        public Order? Order { get; set; }
    }
}
