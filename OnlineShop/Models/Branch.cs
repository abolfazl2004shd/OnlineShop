namespace OnlineShop.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public int ShopId { get; set; }

        [Required]
        public required string BranchName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public required string PostalCode { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }



        [ForeignKey(nameof(ShopId))]
        public required Shop Shop { get; set; }

        public List<Product>? Products { get; set; }
    }
}
