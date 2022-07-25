using AutoMapper;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;

namespace ecommerceweb.API.Profiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDTO>();
            CreateMap<ProductImageDTO, ProductImage>().ForMember(dest => dest.ProductImageId, o => o.Ignore());
        }
    }
}
