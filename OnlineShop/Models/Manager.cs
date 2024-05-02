namespace OnlineShop.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [Required]
        public string SSN { get; set; } = string.Empty;

        [Required]
        public required string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        public Shop? Shop {  get; set; }
    }
}
