using AutoMapper;

namespace BugTracker.Profiles
{
    public class ChannelProfile : Profile
    {
        public ChannelProfile()
        {
            CreateMap<Models.Channel, DTO.ChannelDto>().ReverseMap();
                
        }
    }
}
