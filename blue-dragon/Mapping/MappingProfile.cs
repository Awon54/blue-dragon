using AutoMapper;
using blue_dragon.Dto.V1;
using blue_dragon.Models.V1;

namespace blue_dragon.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActivityRequest, Activity>();
        }
    }
}
