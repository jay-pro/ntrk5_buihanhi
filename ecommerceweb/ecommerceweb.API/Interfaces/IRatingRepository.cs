using ecommerceweb.API.Models;

namespace ecommerceweb.API.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAsync();
        Task<Rating> GetByIdAsync(int ratingId);
        Task<List<Rating>> GetByProductIdAsync(int ratingId);
        Task<Rating> PostAsync(Rating rating);
        Task<Rating> PutAsync(int ratingId, Rating rating);
        Task DeleteAsync(int ratingId);
    }
}
