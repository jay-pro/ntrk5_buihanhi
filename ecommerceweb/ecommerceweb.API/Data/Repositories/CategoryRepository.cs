using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly APIDbContext _context;
        public CategoryRepository(APIDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(item => item.CategoryId == categoryId);
        }
        public async Task<Category> PostAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> PutAsync(int categoryId, Category category)
        {
            var getCategory = await _context.Categories.FirstOrDefaultAsync(item => item.CategoryId == categoryId);
            getCategory.CategoryName = category.CategoryName;
            getCategory.Description = category.Description;
            getCategory.Ordering = category.Ordering;
            getCategory.Published = category.Published;
            await _context.SaveChangesAsync();
            return getCategory;
        }
        public async Task DeleteAsync(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(item => item.CategoryId == categoryId);
            await _context.SaveChangesAsync();
        }
    }
}
