using AgreementManagement.Domain.Entities;
using AgreementManagement.Models;
using AutoMapper;

namespace AgreementManagement.Mapper
{
	public class AgreementMappingProfile : Profile
	{
		public AgreementMappingProfile()
		{
            CreateMap<AgreementCreationViewModel, Agreement>()
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.NewPrice));

            CreateMap<Agreement, AgreementViewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.ProductGroupCode, opt => opt.MapFrom(src => src.Product.ProductGroup.Code))
                .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(src => src.Product.Number))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ProductNewPrice, opt => opt.MapFrom(src => src.ProductPrice));

            CreateMap<Agreement, AgreementUpdateViewModel>()
                .ForMember(dest => dest.NewPrice, opt => opt.MapFrom(src => src.ProductPrice))
                .ReverseMap();

            CreateMap<Agreement, AgreementDeleteViewModel>()
                .ForMember(dest => dest.NewPrice, opt => opt.MapFrom(src => src.ProductPrice));
        }
    }
}
