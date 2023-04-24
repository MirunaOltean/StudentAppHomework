using StudentAppHomework.DTOs;

namespace StudentAppHomework.Services
{
    public interface IUserService
    {
        Task<bool> CheckUsername(string username);
        Task<bool> Register(RegisterDto registerData);
        Task<string> Validate(LoginDto payload);
    }
}