using ecommerceweb.API.Models;

namespace ecommerceweb.API.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(int productId);
        Task<Product> PostAsync(Product image);
        Task<Product> PutAsync(int productId, Product image);
        Task DeleteAsync(int productId);
    }
}
