using System.ComponentModel.DataAnnotations;

namespace MuffinCTF.Domain
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Flag { get; set; }
        public int Points { get; set; }
    }
}
