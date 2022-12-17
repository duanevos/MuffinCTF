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
                },
                Points = 25
            };
            _context.Add(first);

            //OSINT
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "Bobby went on vacation, but he totally forgot in which country he took this picture. Can you help him?",
                    Category = Category.osint,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{japan}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Reverse image search is so good now a days" }
                    },
                    Points = 100,
                    URL = "osint1.png"
                },
                new Challenge()
                {
                    Name = "2",
                    Description = "Bobby booked a room via the website down below to rest before his climbing activities. What is Bobby climbing?",
                    Category = Category.osint,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{mt_fuji}" },
                        new Flag { FlagText = "Muffin{fuji}" },
                        new Flag { FlagText = "Muffin{mount_fuji}" }
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "This looks like a mountain/vulcano" }
                    },
                    Points = 200,
                    URL = "http://www.sunabashirikan.co.jp/",
                },
                new Challenge()
                {
                    Name = "3",
                    Description = "After bobby's climbing adventures he needed something less exhausting, since Bobby loves playing games, he went to the most famous electronica district in Japan, what is the red building behind him called?",
                    Category = Category.osint,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{gigo}"}
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "What famous electionica district(s) are there?" },
                        new Hint{ Text = "Google street view is your best friend" }
                    },
                    Points = 300,
                    URL = "osint3.png"
                },
                new Challenge()
                {
                    Name = "4",
                    Description = "After winning some games, Bobby decided to have a look at the Imperial Palace, he enjoyed the wonderfull park. Then, Bobby went to a place that took him back in time, where did Bobby go?",
                    Category = Category.osint,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{national_museum_of_modern_art_tokyo}" },
                        new Flag { FlagText = "Muffin{national_museum_of_modern_art}" }
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Science is not what we are looking for..." }
                    },
                    Points = 400,
                },



            });;

            await _context.SaveChangesAsync();
        }
    }
}
