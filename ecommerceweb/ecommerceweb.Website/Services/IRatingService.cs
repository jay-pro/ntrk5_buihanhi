using ecommerceweb.SharedModel;
using Refit;

namespace ecommerceweb.Website.Services
{
    public interface IRatingService
    {
        [Get("/rating")]
        Task<List<RatingDTO>> GetRatings();

        [Get("/rating")]
        Task<List<RatingDTO>> GetRatingsByProductId(int ProductId);

        [Get("/rating/{id}")]
        Task<RatingDTO> GetRating(int RatingId);

        [Post("/rating")]
        Task CreateRating([Body] RatingDTO rating);
    }
}
