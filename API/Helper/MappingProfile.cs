using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto.

            CreateMap<Product,ProductForViewDto>()
                .ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<PhotoUrlResolver>());

            // Dto to Domain.

        }
    }
}