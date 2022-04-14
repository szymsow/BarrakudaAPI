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
    }
}
