using System.Runtime.CompilerServices;

namespace OnlineShop.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string SSN { get; set; }

        [Required]
        public required string Sex { get; set; }

        [Required]
        public required decimal Wallet {  get; set; }

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

        public List<Basket> Baskets { get; set; }
        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
