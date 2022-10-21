using BugTracker.Models;

namespace BugTracker.Interface
{
    public interface IChannelRepository
    {
        Task <ICollection<Channel>> GetAllChannelsAsync();
        Task<Channel> GetChannelByIdAsync(int channelId);
        Task<Channel> CreateChannelAsync(Channel channel);
        
        Task<bool> channelExistsAsync(int channelId);
        Task<Channel> UpdateChannelAsync(int channelId,Channel channel);
        Task<Channel> DeleteChannelAsync(int channelId);
        
        

    }
}
