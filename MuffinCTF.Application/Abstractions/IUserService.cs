using MuffinCTF.Domain;

namespace MuffinCTF.Application.Abstractions
{
    public interface IUserService
    {
        Task<User?> GetUser(int id);
        Task<int> GetUserScore(int id);
        Task UpdateUserChallenges(int id);
        Task<bool> Login(string username, string password);
        Task<bool> Register(string username, string password);
        Task<bool> SetToken(string username, string token);
        Task<User?> ValidateToken(string token);


    }
}