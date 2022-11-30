using MuffinCTF.Domain.Models;

namespace MuffinCTF.Application.Abstractions
{
    public interface IChallengeService
    {
        Task<Challenge?> GetChallenge(int id);
        
    }
}
