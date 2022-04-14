namespace Infrastructure.Seeder
{
    public class BarrakudaWebApiSeeder
    {
        private readonly BarrakudaDbContext _dbContext;

        public BarrakudaWebApiSeeder(BarrakudaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    await _dbContext.Roles.AddRangeAsync(roles);
                    await _dbContext.SaveChangesAsync();
                }
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    await _dbContext.Categories.AddRangeAsync(categories);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Motoryzacja"
                },
                new Category()
                {
                    Name = "Kultura"
                },
                new Category()
                {
                    Name = "Elektronika"
                },
                new Category()
                {
                    Name = "Moda"
                },
                new Category()
                {
                    Name = "Dom i ogród"
                },
                new Category()
                {
                    Name = "Sport"
                },
                new Category()
                {
                    Name = "Inne"
                }
            };

            return categories;
        }
    }
}
