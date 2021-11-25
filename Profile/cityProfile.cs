


using AutoMapper;
using broker.Dto;
using broker.Models;

namespace broker.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<broker.Models.City, CityDto>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName));
            CreateMap<CityDto, broker.Models.City>();

        }
     
    }

}
