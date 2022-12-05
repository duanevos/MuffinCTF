using MuffinCTF.Domain.Models;

namespace MuffinCTF.Application.Abstractions
{
    public interface IUserService
    {
        Task<User?> GetUser(int id);
        Task<int> GetUserScore(int id);
        List<User>? GetAllUsers();
        Task<bool> Login(string username, string password);
        Task<bool> Register(string username, string password);
        Task<bool> SetToken(string username, string token);
        Task<User?> ValidateToken(string token);
        Task UpdateUserScore(User user);
    }
}