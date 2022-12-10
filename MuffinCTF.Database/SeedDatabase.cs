using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
            //Need to be updated!
            if (_context.Challenges.Any()) return;
            Challenge first = new()
            {
                Name = "1",
                Description = "You should give yourself around 2 minutes for each challenge. If you get stuck feel free to look at the hints provided to you or ask us for help!",
                Category = Category.first,
                Flags = new List<Flag>() {
                    new Flag { FlagText = "Muffin{Lets_Get_Started}" }
                }
            };
            _context.Add(first);

            await _context.SaveChangesAsync();
        }
    }
}
