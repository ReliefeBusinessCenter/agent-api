


using AutoMapper;
using broker.Dto;
using broker.Models;

namespace broker.Profiles
{
    public class SavingProfile : Profile
    {
        public SavingProfile()
        {  
            CreateMap<broker.Models.Saving, SavingDto>()
            .ForMember(dest => dest.SavingId, opt => opt.MapFrom(src => src.SavingId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.IdentificationCard, opt => opt.MapFrom(src => src.IdentificationCard))
            .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture));
            CreateMap<SavingDto, broker.Models.Saving>();
        }
    }
}
