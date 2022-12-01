using MuffinCTF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuffinCTF.Application.Abstractions
{
    public interface ICCService
    {
        Task<bool> CheckIfCompleted(int challengeId, int userId);
        Task AddCompletedChallenge(int challengeId, int userId);
        Task<List<CompletedChallenges>?> GetCompletedChallenges(int userId);
    }
}
