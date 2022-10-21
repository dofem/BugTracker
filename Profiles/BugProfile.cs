using AutoMapper;

namespace BugTracker.Profiles
{
    public class BugProfile : Profile
    {
        public BugProfile()
        {
            CreateMap<Models.Bug, DTO.BugDto>().ReverseMap();
            CreateMap<Models.Channel, DTO.ChannelDto>().ReverseMap();
        }
    }
}
