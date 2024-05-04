namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public required int BranchId { get; set; }

        [Required]
        public required string ProductName { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public required string ImageSrc { get; set; }

        [Required]
        public required string Size { get; set; }

        [Required]
        public required string Color { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public required string ClothType { get; set; }

        public string? Description { get; set; }

        [Required]
        public required string ProducingCountry { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }



        [ForeignKey(nameof(BranchId))]
        [Required]
        public required Branch Branch { get; set; }

        public List<Comment>? Comments { get; set; }

    }
}
