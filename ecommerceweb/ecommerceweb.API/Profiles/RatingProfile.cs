using AutoMapper;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;

namespace ecommerceweb.API.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDTO>();
            CreateMap<RatingDTO, Rating>().ForMember(dest => dest.RatingId, o => o.Ignore());
        }
    }
}
