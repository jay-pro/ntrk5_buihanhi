using AutoMapper;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;

namespace ecommerceweb.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.ProductId, o => o.Ignore())
                                            .ForMember(dest => dest.ProductImages, o => o.Ignore());
        }
    }
}
