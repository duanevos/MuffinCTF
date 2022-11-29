using MuffinCTF.Domain;

namespace MuffinCTF.Application.Abstractions
{
    public interface IChallengeService
    {
        Task<Challenge?> GetChallenge(int id);
    }
}
