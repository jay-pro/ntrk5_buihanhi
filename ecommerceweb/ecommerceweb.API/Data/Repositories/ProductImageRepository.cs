using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Data.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly APIDbContext _context;
        public ProductImageRepository(APIDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductImage>> GetAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }
        public async Task<ProductImage> GetByIdAsync(int productImageId)
        {
            return await _context.ProductImages.FirstOrDefaultAsync(item => item.ProductImageId == productImageId);
        }
        public async Task<ProductImage> PostAsync(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage;
        }
        public async Task<ProductImage> PutAsync(int productImageId, ProductImage productImage)
        {
            var getProductImage = await _context.ProductImages.FirstOrDefaultAsync(item => item.ProductImageId == productImageId);
            getProductImage.ImageName = productImage.ImageName;
            getProductImage.ImageUrl = productImage.ImageUrl;
            await _context.SaveChangesAsync();
            return getProductImage;
        }
        public async Task DeleteAsync(int productImageId)
        {
            var productImage = await _context.ProductImages.FirstOrDefaultAsync(item => item.ProductImageId == productImageId);
            await _context.SaveChangesAsync();
        }
    }
}
