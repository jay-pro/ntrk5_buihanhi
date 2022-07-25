using ecommerceweb.API.Models;

namespace ecommerceweb.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAsync();
        Task<Category> GetByIdAsync(int categoryId);
        Task<Category> PostAsync(Category category);//image
        Task<Category> PutAsync(int categoryId, Category category);//image
        Task DeleteAsync(int categoryId);
    }
}
