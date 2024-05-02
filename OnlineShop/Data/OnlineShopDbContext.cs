namespace OnlineShop.Data
{
    public class OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : DbContext(options)
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
