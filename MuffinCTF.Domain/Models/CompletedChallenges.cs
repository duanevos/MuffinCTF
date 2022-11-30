using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuffinCTF.Domain.Models
{
    public class CompletedChallenges
    {
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
