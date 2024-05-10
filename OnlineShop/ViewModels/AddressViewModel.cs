namespace OnlineShop.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public required string PostalCode { get; set; }
        [Required]
        public required string City { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string Plaque { get; set; }
    }
}
