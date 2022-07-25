using ecommerceweb.SharedModel;
using Refit;

namespace ecommerceweb.Website.Services
{
    public interface ICategoryService
    {
        [Get("/Categories")]
        Task<List<CategoryDTO>> GetCategories();

        [Get("/Categories/{CategoryId}")]
        Task<CategoryDTO> GetCategory(int id);
    }
}
