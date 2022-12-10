
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MuffinCTF.Application.Abstractions;
using MuffinCTF.Database;
using MuffinCTF.Domain.Models;
using System.ComponentModel;
using System.Net;

namespace MuffinCTF.Application.Services
{
    public class UserService : IUserService
    {

        private readonly CTFContext _context;
        public UserService(CTFContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(int id)
        {
            var result = await _context.Users.FindAsync(id);
            return result;
        }

        public List<User>? GetAllUsers()
        {
            if (_context.Users.Any())
            {
                return _context.Users.ToList();
            }
            return null;
        }

        public async Task<int> GetUserScore(int id)
        {
            var result = await _context.Users.FindAsync(id);
            if (result == null) return 0;
            return result.Points;
        }

        public async Task UpdateUserScore(User user, int points)
        {
            user.Points += points;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        
        Task<User?> IUserService.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> ValidateToken(string token)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Token == token);
            if (result == null) return null;
            return result;
        }

        public async Task<bool> Login(string username, string password)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (result == null) return false;
            return BCrypt.Net.BCrypt.Verify(password, result.Password);
        }

        public async Task<bool> SetToken(string username, string token)
        {
            {
                var result = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
                if (result != null)
                {
                    result.Token = token;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> Register(string username, string password)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username)) return false;
            var user = new User
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

