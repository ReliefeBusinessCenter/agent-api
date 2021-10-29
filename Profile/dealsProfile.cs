



using AutoMapper;
using broker.Dto;
using broker.Models;

namespace broker.Profiles
{
    public class DealsProfile : Profile
    {
        public DealsProfile()
        {
            CreateMap<broker.Models.Deals, DealsDto>()
            .ForMember(dest => dest.DealsId, opt => opt.MapFrom(src => src.DealsId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
              .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(dest => dest.ProductModel, opt => opt.MapFrom(src => src.ProductModel))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.PaymentOption, opt => opt.MapFrom(src => src.PaymentOption))
             .ForMember(dest => dest.DeliveryOption, opt => opt.MapFrom(src => src.DeliveryOption))
               .ForMember(dest => dest.BrokerId, opt => opt.MapFrom(src => src.BrokerId))
             .ForMember(dest => dest.DeliveryOption, opt => opt.MapFrom(src => src.DeliveryOption))
                  .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
             .ForMember(dest => dest.DeliveryOption, opt => opt.MapFrom(src => src.DeliveryOption))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer));



            CreateMap<DealsDto, broker.Models.Deals>();

        }
        //  







    }

}



