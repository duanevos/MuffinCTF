using MuffinCTF.Domain.Enum;
using MuffinCTF.Domain.Models;

namespace MuffinCTF.Application.Abstractions
{
    public interface IChallengeService
    {
        Task<Challenge?> GetChallenge(int id);
        Task<List<Challenge>?> GetChallengesByCategory(Category category);
        
    }
}
