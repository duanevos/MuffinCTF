using System.ComponentModel.DataAnnotations;
using MuffinCTF.Domain.Enum;

namespace MuffinCTF.Domain.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Flag { get; set; }
        public int Points { get; set; }
        public ICollection<CompletedChallenges> CompletedChallenges { get; set; }
        public List<Hint> Hints { get; set; }
    }
}
