using ecommerceweb.SharedModel;
using Refit;

namespace ecommerceweb.Website.Services
{
    public interface IProductService
    {
        [Get("/Products")]
        Task<List<ProductDTO>> GetProducts();

        [Get("/Products/{ProductId}")]
        Task<ProductDTO> GetProduct(int ProductId);

        [Post("/Product")]
        Task CreateProductImage([Body] ProductDTO productImage);
    }
}
