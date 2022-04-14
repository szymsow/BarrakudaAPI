namespace Infrastructure.Config
{
    public static class ModelBuilderConfig
    {
        public static void AddUserConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(20)
                .IsRequired();
        }
        public static void AddProductConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
        public static void AddCategoryConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
