using Microsoft.EntityFrameworkCore;
using MuffinCTF.Domain;
using MuffinCTF.Domain.Models;

namespace MuffinCTF.Database
{
    public class CTFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<CompletedChallenges> CompletedChallenges { get; set; }

        public CTFContext(DbContextOptions<CTFContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompletedChallenges>()
                .HasKey(cc => new { cc.UserId, cc.ChallengeId });
            
            modelBuilder.Entity<CompletedChallenges>()
                .HasOne(c => c.Challenge)
                .WithMany(cc => cc.CompletedChallenges)
                .HasForeignKey(c => c.ChallengeId);
            
            modelBuilder.Entity<CompletedChallenges>()
                .HasOne(u => u.User)
                .WithMany(cc => cc.CompletedChallenges)
                .HasForeignKey(u => u.UserId);
            
        }



        
    }
}