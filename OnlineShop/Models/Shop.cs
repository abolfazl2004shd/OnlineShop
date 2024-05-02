namespace OnlineShop.Models
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        [Required]
        public int ManagerId { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        public List<Branch>? Branches { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager Manager { get; set; }
    }
}
