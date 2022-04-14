namespace Infrastructure.Context
{
    public class BarrakudaDbContext : DbContext
    {
        public BarrakudaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddUserConfig();
            modelBuilder.AddProductConfig();
            modelBuilder.AddCategoryConfig();
        }
    }
}
