
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

        public async Task<List<Challenge>?> GetChallengesByCategory(Category category)
        {
            return await _context.Challenges.Where(x => x.Category == category).Include(x => x.Hints).Include(x => x.Flags).ToListAsync();
        }

        public async Task<bool> ValidateChallengeFlag(Challenge challenge, string flag)
        {
            var result = await _context.Flags.FirstOrDefaultAsync(x => x.Challenge == challenge && x.FlagText == flag);
            if (result != null) return true;
            return false;
        }

    }
}
