namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task CreateUser(RegisterDto registerDto);
        Task<string> GenerateJwt(LoginDto dto);
        Task<bool> IsMailIsTaken(string mail);
    }
}
