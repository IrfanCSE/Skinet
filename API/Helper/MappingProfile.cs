using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductForViewDto>()
                .ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<PhotoUrlResolver>());

            CreateMap<Address,AddressDto>().ReverseMap();
            CreateMap<BasketDto,Basket>();
            CreateMap<BasketItemDto,BasketItem>();
        }
    }
}