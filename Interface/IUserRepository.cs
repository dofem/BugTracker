using BugTracker.Models;

namespace BugTracker.Interface
{
    public interface IUserRepository
    {
       Task<User> Authenticate(string username, string password);
    }
}
