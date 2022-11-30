using System.ComponentModel.DataAnnotations;

namespace MuffinCTF.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Points { get; set; } = 0;
        public string Token { get; set; } = "";
        public ICollection<CompletedChallenges> CompletedChallenges { get; set; }
    }
}
