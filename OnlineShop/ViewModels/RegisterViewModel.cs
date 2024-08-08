namespace OnlineShop.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string SSN { get; set; }

        [Required]
        public required string Gender { get; set; }


        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public required string ConfirmedPassword { get; set; }
    }
}
