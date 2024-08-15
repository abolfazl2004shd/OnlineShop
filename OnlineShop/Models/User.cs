namespace OnlineShop.Models
{
    public class User
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string SSN { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public decimal Wallet { get; set; }

        [Required]
        public string Role { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public List<Basket>? Baskets { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Comment>? Comments { get; set; }

        public string FullName()
        {
            string FullName = $"{FirstName} {LastName}";
            return FullName;
        }
    }
}
