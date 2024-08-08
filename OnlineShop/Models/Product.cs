namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public  string ProductName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.ImageUrl)]
        public  string ImageSrc { get; set; } = string.Empty;

        [Required]
        public  string Size { get; set; } = string.Empty;

        [Required]
        public  string Color { get; set; } = string.Empty;

        public decimal Discount { get; set; } = 0m;

        public string Description { get; set; } = string.Empty;

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }


        public List<Comment>? Comments { get; set; }


        public decimal GetDiscount()
        {
            return ((Discount * Price) / 100).FormatDecimal();
        }
        public decimal GetFinalPrice()
        {
            return (Price - GetDiscount()).FormatDecimal();
        }

    }
}
