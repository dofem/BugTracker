using BugTracker.Data;
using BugTracker.Interface;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Channels;

namespace BugTracker.Repository
{
    public class BugRepository:IBugRepository
    {
        private ApplicationDbContext _context;

        public BugRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BugExistsAsync(int bugId)
        {
            return await _context.Bugs.AnyAsync(bug => bug.Id == bugId);
        }

        public async Task<ICollection<Bug>> GetAllBugsAsync()
        {
            return await _context.Bugs.
                  Include(u => u.User).
                  Include(c => c.Channel).ToListAsync();
        }

        public async  Task<Bug> GetBugByIdAsync(int bugId)
        {
            return await _context.Bugs.Include(u => u.User).
                Include(c => c.Channel).Where(b => b.Id == bugId).FirstOrDefaultAsync();
        }


        
        public async Task<Bug> CreateBugAsync(Bug bug)
        {
            await _context.AddAsync(bug);
            await _context.SaveChangesAsync();
            return bug;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<Bug> UpdateBugAsync(int createId, Bug bug)
        {
            var existingBug = await _context.Bugs.FirstOrDefaultAsync();
            if (existingBug == null)
                return null;

            existingBug.Title = bug.Title;
            existingBug.Description = bug.Description;
            existingBug.Severity = bug.Severity;
            existingBug.DateCreated = bug.DateCreated;
            existingBug.Status = bug.Status;
            existingBug.UserId = bug.UserId;
            existingBug.ChannelId = bug.ChannelId;

            await _context.SaveChangesAsync();
            return existingBug;
        }


        public async Task<Bug> DeleteBugAsync(int bugId)
        {
           var bug = await _context.Bugs.Include(u => u.User).
                Include(c => c.Channel).Where(b => b.Id == bugId).FirstOrDefaultAsync();

            if (bug == null)
                return null;

            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();
            return bug;
            
        }
    }
    
}
