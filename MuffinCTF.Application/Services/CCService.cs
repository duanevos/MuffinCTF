using Microsoft.EntityFrameworkCore;
using MuffinCTF.Database;
using MuffinCTF.Domain.Models;

namespace MuffinCTF.Application.Services
{
    public class CCService
    {
        private readonly CTFContext _context;
        public CCService(CTFContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfCompleted(int challengeId, int userId)
        {
            var result = await _context.CompletedChallenges.FirstOrDefaultAsync(x => x.ChallengeId == challengeId && x.UserId == userId);
            if (result != null) return true;
            return false;
        }

        public async Task AddCompletedChallenge(int challengeId, int userId)
        {
            var completedChallenges = new CompletedChallenges
            {
                ChallengeId = challengeId,
                UserId = userId
            };
            await _context.CompletedChallenges.AddAsync(completedChallenges);
            await _context.SaveChangesAsync();
        }
    }
}
