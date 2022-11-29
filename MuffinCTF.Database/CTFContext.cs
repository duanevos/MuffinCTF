using Microsoft.EntityFrameworkCore;
using MuffinCTF.Domain;

namespace MuffinCTF.Database
{
    public class CTFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }

        public CTFContext(DbContextOptions<CTFContext> options)
        : base(options)
        {
        }
    }
}