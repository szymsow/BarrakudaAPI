namespace Infrastructure.Context
{
    public class BarrakudaDbContext : DbContext
    {
        public BarrakudaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddUserConfig();
        }
    }
}
