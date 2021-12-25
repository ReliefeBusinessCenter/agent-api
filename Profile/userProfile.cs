using AutoMapper;
using broker.Dto;
using broker.Models;

namespace broker.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<broker.Models.User, UserDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)) 
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            // .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Subcity, opt => opt.MapFrom(src => src.Subcity))
            .ForMember(dest => dest.Kebele, opt => opt.MapFrom(src => src.Kebele))
              .ForMember(dest => dest.Subcity, opt => opt.MapFrom(src => src.Subcity))
            // .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
            // .ForMember(dest => dest.Longtiude, opt => opt.MapFrom(src => src.Longtiude))
            .ForMember(dest => dest.IdentificationCard, opt => opt.MapFrom(src => src.IdentificationCard));
            CreateMap<UserDto, broker.Models.User>();

        }
        




    }

}