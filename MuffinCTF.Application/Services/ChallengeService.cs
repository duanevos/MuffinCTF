﻿
using MuffinCTF.Application.Abstractions;
using MuffinCTF.Database;
using MuffinCTF.Domain;

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
            return await _context.Challenges.FindAsync(id);
        }
    }
}
