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
                Flag = "Muffin{Lets_Get_Started}",
            };
            _context.Add(first);

            List<Challenge> audiography = new()
            {
                new Challenge()
                {
                    Name = "1",
                    Category = Category.audiography,
                    Description = "Beep. Boop. Beep. Boop.Beep. Boop. Beep. Boop.",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Hmm... this sounds like morse code!",
                        }
                    },
                    Flag = "Muffin{spinach}"
                },
                new Challenge()
                {
                    Name = "2",
                    Category = Category.audiography,
                    Description = "Sometimes it is good to visualize",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Use a tool for visualizing sound (Sonic Visualizer)"
                        }
                    },
                    Flag = "Muffin{use_vim}"
                },
                new Challenge()
                {
                    Name = "3",
                    Category = Category.audiography,
                    Description = "Where are these sounds from?",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "This sounds like DTMF tones."
                        }
                    },
                    Flag = "Muffin{japan_mcdonalds}"
                },
            };
            _context.Challenges.AddRange(audiography);
            
            List<Challenge> cryptography = new()
            {
                new Challenge()
                {
                    Name = "1",
                    Category = Category.cryptography,
                    Description = "Is this the base I am expecting?",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "This looks like base64"
                        }
                    },
                    Flag = "Muffin{Th1s_Is_3asy_R1ghT}"
                },
                new Challenge()
                {
                    Name = "2",
                    Category = Category.cryptography,
                    Description = "Rotation is key.",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Is this what they call a caesar cipher?"
                        }
                    },
                    Flag = "Muffin{yOu_EarNed_a_M3daL}"
                }
            };
            _context.Challenges.AddRange(cryptography);

            List<Challenge> osint = new()
            {
                new Challenge()
                {
                    Name = "1",
                    Category = Category.osint,
                    Description = "Bobby went on vacation, but he totally forgot in which country he took this picture. Can you help him?",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Reverse image search is so good now a days!"
                        }
                    },
                    Flag = "Muffin{japan}"
                },
                new Challenge()
                {
                    Name = "2",
                    Category = Category.osint,
                    Description = "Rotation is key.",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Is this what they call a caesar cipher?"
                        }
                    },
                    Flag = "Muffin{yOu_EarNed_a_M3daL}"
                },
                new Challenge()
                {
                    Name = "3",
                    Category = Category.osint,
                    Description = "After bobby's climbing adventures he needed something less exhausting, since Bobby loves playing games, he went to the most famous electionica district in Japan, how is the red building behind him called?",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Is this what they call a caesar cipher?"
                        },
                        new Hint()
                        {
                            Text = "Google street view is your best friend"
                        }
                    },
                    Flag = "Muffin{gigo}"
                },
                new Challenge()
                {
                    Name = "4",
                    Category = Category.osint,
                    Description = "After winning some games, Bobby decided to have a look at the Imperial Palace, he enjoyed the wonderfull park. Then, Bobby went to a place that took him back in time, where did Bobby go?",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Science is not what we are looking for..."
                        },
                    },
                    Flag = "Muffin{national_museum_of_modern_art}"
                }
            };
            _context.Challenges.AddRange(osint);

            List<Challenge> steganography = new()
            {
                new Challenge()
                {
                    Name = "1",
                    Category = Category.steganography,
                    Description = "I love using stegano in python ;)",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "pip install stegano"
                        },
                        new Hint()
                        {
                            Text = "https://pypi.org/project/stegano/"
                        }
                    },
                    Flag = "Muffin{use_linux}"
                },
                new Challenge()
                {
                    Name = "2",
                    Category = Category.steganography,
                    Description = "Some things are hidden in plain sight.",
                    Hints = new List<Hint>()
                    {
                        new Hint()
                        {
                            Text = "Metadata"
                        },
                        new Hint()
                        {
                            Text = "Maybe something is encoded..."
                        }
                    },
                    Flag = "Muffin{bobby_loves_muffins}"
                },

            };
            _context.Challenges.AddRange(steganography);
        }
    }
}
