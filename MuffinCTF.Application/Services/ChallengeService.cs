
using Microsoft.EntityFrameworkCore;
using MuffinCTF.Application.Abstractions;
using MuffinCTF.Database;
using MuffinCTF.Domain.Enum;
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

        public async Task<List<Challenge>?> GetChallengesByCategory(Category category)
        {
            return await _context.Challenges.Where(x => x.Category == category).Include(x => x.Hints).ToListAsync();
        }

    }
}
