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
            
            if (_context.Challenges.Any()) return;
            
            //First Challenge
            Challenge first = new()
            {
                Name = "1",
                Description = "If you get stuck feel free to look at the hints provided to you or ask us for help. Double click hints to reveal them, BUT be aware they will cost you points! All flags the following prefix: Muffin{}",
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
                    Description = "Bobby went on vacation, but he totally forgot in which country he took this picture. Can you help him? Flag format: Muffin{solution}\r\n Solution in lowercase",
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
                    Description = "Bobby booked a room via the website down below to rest before his climbing activities. What is Bobby climbing? Flag format: Muffin{solution_solution}\r\n Solution in lowercase",
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
                    Description = "After bobby's climbing adventures he needed something less exhausting, since Bobby loves playing games, he went to the most famous electronica district in Japan, what is the red building behind him called? Flag format: Muffin{solution}\r\n Solution in lowercase",
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
                    Description = "After winning some games, Bobby decided to have a look at the Imperial Palace, he enjoyed the wonderfull park. Then, Bobby went to a place that took him back in time, where did Bobby go? Flag format: Muffin{solution}\r\n Solution in lowercase",
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
            });

            //STEGANOGRAPHY
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "I love using stegano in python ;) Flag format: Muffin{solution}\r\n Solution in lowercase",
                    Category = Category.steganography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{use_linux}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "pip install stegano" },
                        new Hint{ Text = "https://pypi.org/project/stegano/" }
                    },
                    Points = 100,
                    URL = "steganography1.png"
                },
                new Challenge()
                {
                    Name = "2",
                    Description = "Sometimes things are hidden in plain sight. Flag format: Muffin{solution}\r\n Solution in lowercase",
                    Category = Category.steganography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{bobby_loves_muffins}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Metadata" },
                        new Hint{ Text = "Maybe something is encoded..." }
                    },
                    Points = 200,
                    URL = "steganography2.png",
                }
            });

            //WEB
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "Some things are better left hidden...",
                    Category = Category.web,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{Muff1ns_Ar3_Imp0Rt4nt}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "What is in the page source?" }
                    },
                    Points = 100,
                    URL = "https://bobbystravelingblog.up.railway.app/"
                },
                new Challenge()
                {
                    Name = "2",
                    Description = "Who are you? Who am I?",
                    Category = Category.web,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{C00kies_Ar3_Dang3r0us}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Who do I want to be?" },
                    },
                    Points = 200,
                    URL = "https://bobbysmuffins.up.railway.app/"
                },
                new Challenge()
                {
                    Name = "3",
                    Description = "Maybe you read it in the newspaper, my cousin Bobby is in trouble, he owes a lot of money to shady people." +
                                  " He really doesn't deserve this, can you please try to help him? " +
                                  "P.S. His muffins banking number is: Muff1n_334455 (50K muffins should be enough)",
                    Category = Category.web,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{N0T_ThaT_3Asy_R1ghT}" },
                    },
                    Hints = new List<Hint>()
                    {
                        new Hint{ Text = "Where do we disallow pages from being indexed by google?" },
                        new Hint{ Text = "Who could have a weak password?" },
                        new Hint{ Text = "Emails can contain important things" }
                    },
                    Points = 300,
                    URL = "https://bankofmuffins.up.railway.app/"
                }
            });

            //Audiography
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "Beep. Boop. Beep. Boop.Beep. Boop. Beep. Boop. Flag format: Muffin{solution}\r\n Solution in lowercase!",
                    Category = Category.audiography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{spinach}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Hmm... this sounds like morse code!" }
                    },
                    Points = 100,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:u:/g/personal/20089600_student_hhs_nl/EaQN9Ys6ishApjeHKt3Cqt4BUIpns_oj9AuyPyb5ndC36Q?e=2qFM4O"
                },
                new Challenge()
                {
                    Name = "2",
                    Description = "Sometimes it is good to visualize. Flag format: Muffin{solution}\r\n Solution in lowercase!",
                    Category = Category.audiography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{use_vim}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Use a tool for visualizing sound -> Sonic Visualizer" },
                    },
                    Points = 200,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:u:/g/personal/20089600_student_hhs_nl/EYGpYSfClMhOgvzms4Mb9ycBtbn7ZGpMtlilcW66Y8oqeA?e=VFuDom"
                },
                new Challenge()
                {
                    Name = "3",
                    Description = "Where are these sounds from? Flag format: Muffin{country_restaurant}\r\n Solution in lowercase!",
                    Category = Category.audiography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{japan_mcdonald's}" },
                        new Flag { FlagText = "Muffin{japan_mcdonalds}" }
                    },
                    Hints = new List<Hint>()
                    {
                        new Hint{ Text = "This sounds like DTMF tones" },
                    },
                    Points = 300,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:u:/g/personal/20089600_student_hhs_nl/Eb5hZkNyx1RAp441pyl461wBSyO4Wf4cKiY7SoJywkmvJA?e=6s6IAl"
                }
            });

            //CRYPTOGRAPHY
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "Is this the base I am expecting? Flag format: Muffin{solution}",
                    Category = Category.cryptography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{Th1s_Is_3asy_R1ghT}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "This looks like base64" }
                    },
                    Points = 100,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:t:/g/personal/20089600_student_hhs_nl/EeQvCTN6wxVDh8941iymzP0Blp6GeF8SHzMK-7JVOnUqIA?e=TwwVYm"
                },
                new Challenge()
                {
                    Name = "2",
                    Description = "Rotation is key! Flag format: Muffin{solution}",
                    Category = Category.cryptography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{yOu_EarNed_a_M3daL}" },
                    },
                    Hints = new List<Hint>(){
                        new Hint{ Text = "Is this what they call a caesar cipher?" },
                    },
                    Points = 200,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:t:/g/personal/20089600_student_hhs_nl/EVSTI6W5VzZLuxjQZhcQkhYBGKrENyjDo2mNLQp87iqYpg?e=U1VmiI"
                },
                new Challenge()
                {
                    Name = "3",
                    Description = "This secret text uses XOR with a single byte, but luckily no one knows it, so it will stay secure forever. Flag format: Muffin{solution}",
                    Category = Category.cryptography,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{I_L0V3_CrYpto}" },
                    },
                    Points = 300,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:t:/g/personal/20089600_student_hhs_nl/EXWJm-MiBgZBrboXbv3s3R0B4soFzTx7EerxklOwHcYBeQ?e=T7cA3S"
                }
            });

            //PWN
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "Start the box via tryhackme",
                    Category = Category.pwn,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{H4CK_TH3_W0RLD_321}" },
                    },
                    Hints = new List<Hint>()
                    {
                        new Hint{ Text = "Did you look for SUID binaries?" },
                    },
                    Points = 100,
                    URL = "https://tryhackme.com/room/capturethemuffinspwn1"
                },
                new Challenge()
                {
                    Name = "2",
                    Description = "Start the box via tryhackme",
                    Category = Category.pwn,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{Y0u_D1d_g0oD_!_Nic3_PwN}" },
                    },
                    Hints = new List<Hint>()
                    {
                        new Hint{ Text = "root is probably the file owner" },
                        new Hint{ Text = "Ssh has a special parameter for this file" }
                    },
                    Points = 200,
                    URL = "https://tryhackme.com/room/capturethemuffinspwn2"
                },
                new Challenge()
                {
                    Name = "3",
                    Description = "Start the box via tryhackme",
                    Category = Category.pwn,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{Apache_1s_S0_W3iRd}" },
                    },
                    Hints = new List<Hint>()
                    {
                        new Hint{ Text = "What dangerous file are we able to upload?" },
                        new Hint{ Text = "Interactive shells are important" }
                    },
                    Points = 300,
                    URL = "https://tryhackme.com/room/capturethemuffinspwn3"
                }
            });

            //Reversing
            _context.AddRange(new List<Challenge>
            {
                new Challenge()
                {
                    Name = "1",
                    Description = "Download the files and start reversing :)",
                    Category = Category.reversing,
                    Flags = new List<Flag>()
                    {
                        new Flag { FlagText = "Muffin{Y0u_D1d_w3Ll}" },
                    },
                    Points = 100,
                    URL = "https://dehaagsehogeschool-my.sharepoint.com/:u:/g/personal/20089600_student_hhs_nl/EbMpKxmS7UlAonZzTdnZAwkBVjyGq_QsAK8Xu2slx5kCTQ?e=FLEJCC"
                }
            });
            await _context.SaveChangesAsync();
        }
    }
}
