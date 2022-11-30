
using Microsoft.EntityFrameworkCore;
using MuffinCTF.Application.Abstractions;
using MuffinCTF.Database;
using MuffinCTF.Domain.Models;

namespace MuffinCTF.Application.Services
{
    public class ChallengeService : IChallengeService
    {

        private readonly CTFContext _context;
        public ChallengeService(CTFContext context)
        {
            _context = context;

        }
        public async Task<Challenge?> GetChallenge(int id)
        {
            return await _context.Challenges.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
