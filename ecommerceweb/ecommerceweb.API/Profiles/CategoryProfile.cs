using AutoMapper;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;

namespace ecommerceweb.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>().ForMember(dest => dest.CategoryId, o => o.Ignore())
                                                .ForMember(dest => dest.Products, o => o.Ignore());
        }
    }
}
