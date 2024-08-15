namespace OnlineShop.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(350)]
        public required string Description { get; set; }

        [Required]
        [DataType(dataType: DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        //[Required]
        //public required string Overview { get; set; }

        //public required bool SendAnonymously { get; set; } = false;



        [ForeignKey(nameof(CustomerId))]
        [Required]
        public  User Customer { get; set; }
        [ForeignKey(nameof(ProductId))]
        [Required]
        public  Product Product { get; set; }
    }
}
