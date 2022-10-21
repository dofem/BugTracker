using BugTracker.Models;

namespace BugTracker.Interface
{
    public interface IBugRepository
    {
        Task<ICollection<Bug>> GetAllBugsAsync();
        
        Task<Bug> GetBugByIdAsync(int bugId);
        
        Task<bool> BugExistsAsync (int bugId);

        Task<Bug> CreateBugAsync(Bug bug);
        Task<Bug> UpdateBugAsync(int createId,Bug bug);
        Task<Bug>DeleteBugAsync(int bugId);

        Task<bool> Save();
    }
}