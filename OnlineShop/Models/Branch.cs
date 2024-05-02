using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public int ShopId { get; set; }

        [Required]
        public string BranchName { get; set; } = string.Empty;

        [ForeignKey(nameof(ShopId))]
        public required Shop Shop { get; set; }

        public List<Product>? Products { get; set; }
    }
}
