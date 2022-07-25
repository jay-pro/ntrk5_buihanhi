using ecommerceweb.SharedModel;
using Refit;

namespace ecommerceweb.Website.Services
{
    public interface IProductImageService
    {
        [Get("/ProductImage")]
        Task<List<ProductImageDTO>> GetProductImages();

        [Get("/ProductImage/{ProductImageId}")]
        Task<ProductImageDTO> GetProductImage(int ProductImageId);

        [Post("/ProductImage")]
        Task CreateProductImage([Body] ProductImageDTO productImage);

        [Put("/ProductImage/{ProductImageId}")]
        Task UpdateProductImage(int ProductImageId, [Body] ProductImageDTO productImage);

        [Delete("/ProductImage/{ProductImageId}")]
        Task DeleteProductImage(int ProductImageId);
    }
}
