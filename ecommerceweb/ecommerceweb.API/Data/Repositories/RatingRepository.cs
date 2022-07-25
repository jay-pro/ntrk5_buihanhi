using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly APIDbContext _context;
        public RatingRepository(APIDbContext context)
        {
            _context = context;
        }
        public async Task<List<Rating>> GetAsync()
        {
            return await _context.Ratings.ToListAsync();
        }
        public async Task<Rating> GetByIdAsync(int ratingId)
        {
            return await _context.Ratings.FirstOrDefaultAsync(item => item.RatingId == ratingId);
        }
        public async Task<List<Rating>> GetByProductIdAsync(int productId)
        {
            return await _context.Ratings.Where(item => item.ProductId == productId).ToListAsync();
        }
        public async Task<Rating> PostAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }
        public async Task<Rating> PutAsync(int ratingId, Rating rating)
        {
            var getRating = await _context.Ratings.FirstOrDefaultAsync(item => item.RatingId == ratingId);
            getRating.Content = rating.Content;
            getRating.Stars = rating.Stars;
            await _context.SaveChangesAsync();
            return getRating;
        }
        public async Task DeleteAsync(int ratingId)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(item => item.RatingId == ratingId);
            await _context.SaveChangesAsync();
        }
    }
}
