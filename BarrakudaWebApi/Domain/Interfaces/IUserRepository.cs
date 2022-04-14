namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterUser(User user);
        Task<User> IsUserExist(string email);
        Task<bool> IsMailIsTaken(string mail);
    }
}
