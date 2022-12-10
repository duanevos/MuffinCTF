using MuffinCTF.Domain.Enum;
using MuffinCTF.Domain.Models;

namespace MuffinCTF.Application.Abstractions
{
    public interface IChallengeService
    {
        Task<List<Challenge>?> GetChallengesByCategory(Category category);
        Task<bool> ValidateChallengeFlag(Challenge challenge, string flag);


    }
}
