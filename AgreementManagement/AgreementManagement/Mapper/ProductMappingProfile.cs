using AgreementManagement.Domain.Entities;
using AgreementManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgreementManagement.Mapper
{
	public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
        {
            CreateMap<Product, SelectListItem>()
                 .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Number));

            CreateMap<ProductGroup, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Code));
        }
	}
}
