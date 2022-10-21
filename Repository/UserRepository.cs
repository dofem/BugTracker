using BugTracker.Data;
using BugTracker.Interface;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserName.ToLower()==username.ToLower() && x.PassWord == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
