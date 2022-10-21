using BugTracker.Data;
using BugTracker.Interface;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BugTracker.Repository
{
    public class ChannelRepository : IChannelRepository
    {
        private ApplicationDbContext _context;

        public ChannelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task<Channel> CreateChannelAsync(Channel channel)
        {
            await _context.AddAsync(channel);
            await _context.SaveChangesAsync();
            return channel;

        }

        public async Task<ICollection<Channel>> GetAllChannelsAsync()
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task<Channel> GetChannelByIdAsync(int channelId)
        {
            return await _context.Channels.Where(p => p.ChannelId == channelId).FirstOrDefaultAsync();
        }

        public async Task<bool> channelExistsAsync(int channelId)
        {
            return await _context.Channels.AnyAsync(channel => channel.ChannelId == channelId);
        }

        public async Task<Channel> UpdateChannelAsync(int channelId,Channel channel)
        {

            var existingChannel = await _context.Channels.Where(c => c.ChannelId == channelId).FirstOrDefaultAsync();
            if (existingChannel == null)
                return null;

            existingChannel.Name = channel.Name;

            await _context.SaveChangesAsync();
            return existingChannel;
        }

        public async Task<Channel> DeleteChannelAsync(int channelId)
        {
            var channel = await _context.Channels.Where(c => c.ChannelId == channelId).FirstOrDefaultAsync();
            if (channel == null)
                return null;
            
            _context.Channels.Remove(channel);
            await _context.SaveChangesAsync();
            return channel;

        }

        
    }
}
