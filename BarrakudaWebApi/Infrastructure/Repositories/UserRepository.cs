namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BarrakudaDbContext _dbContext;

        public UserRepository(BarrakudaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsMailIsTaken(string mail)
        {
            var result = await _dbContext.Users
                .AnyAsync(u => u.Email == mail);
            return result;
        }

        public async Task<User> IsUserExist(string email)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task RegisterUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
