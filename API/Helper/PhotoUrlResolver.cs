using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helper {
    public class PhotoUrlResolver : IValueResolver<Product,ProductForViewDto,string>
    {
        private readonly IConfiguration _configuration;
        public PhotoUrlResolver (IConfiguration configuration) {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductForViewDto destination, string destMember, ResolutionContext context)
        {
            return _configuration["ApiUrl"]+source.PictureUrl;
        }
    }
}