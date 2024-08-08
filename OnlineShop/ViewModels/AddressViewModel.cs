namespace OnlineShop.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public int BasketId { get; set; }

        public string PostalCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;


        public string Street { get; set; } = string.Empty;


        public string Plaque { get; set; } = string.Empty;
    }
}
