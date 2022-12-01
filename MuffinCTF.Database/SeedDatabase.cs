using MuffinCTF.Domain.Enum;
using MuffinCTF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuffinCTF.Database
{
    public class SeedDatabase
    {
        private readonly CTFContext _context;
        public SeedDatabase(CTFContext context)
        {
            _context = context;
        }

        public async Task AddToDatabase()
        {
            await AddChallenges();
            await _context.SaveChangesAsync();
        }

        private async Task AddChallenges()
        {
            Challenge c1 = new()
            {
                Name = "FirstChallenge",
                Description = "Welcome",
                Points = 25,
                Category = Category.first,
                Flag = "Muffin{Lets_Get_Started}"
            };
            Challenge c2 = new()
            {
                Name = "1",
                Description = "",
                Points = 50,
                Category = Category.web,
                Flag = "Muffin{897ja}",
                Hints = new List<Hint>()
                {
                    new Hint()
                    {
                        Text = "Hint 1"
                    },
                    new Hint()
                    {
                        Text = "Hint 2"
                    }
                }
            };
            Challenge c6 = new()
            {
                Name = "2",
                Description = "",
                Points = 50,
                Category = Category.web,
                Flag = "Muffin{897ja}",
                Hints = new List<Hint>()
                {
                    new Hint()
                    {
                        Text = "Hint 1"
                    },
                    new Hint()
                    {
                        Text = "Hint 2"
                    }
                }
            };
            Challenge c3 = new()
            {
                Name = "3",
                Description = "",
                Points = 50,
                Category = Category.web,
                Flag = "Muffin{897ja}",
                Hints = new List<Hint>()
                {
                    new Hint()
                    {
                        Text = "Hint 1"
                    },
                    new Hint()
                    {
                        Text = "Hint 2"
                    }
                }
            };
            Challenge c4 = new()
            {
                Name = "4",
                Description = "",
                Points = 50,
                Category = Category.web,
                Flag = "Muffin{897ja}",
                Hints = new List<Hint>()
                {
                    new Hint()
                    {
                        Text = "Hint 1"
                    },
                    new Hint()
                    {
                        Text = "Hint 2"
                    }
                }
            };

            await _context.Challenges.AddRangeAsync(c1, c2, c3, c4, c6);
        }
    }
}
