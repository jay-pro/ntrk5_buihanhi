using ecommerceweb.API.Models;

namespace ecommerceweb.API.Interfaces
{
    public interface IProductImageRepository
    {
        Task<List<ProductImage>> GetAsync();
        Task<ProductImage> GetByIdAsync(int productImageId);
        Task<ProductImage> PostAsync(ProductImage productImage);//image
        Task<ProductImage> PutAsync(int productImageId, ProductImage productImage);//image
        Task DeleteAsync(int productImageId);
    }
}
