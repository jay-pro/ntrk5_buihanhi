using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIDbContext _context;
        public ProductRepository(APIDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(item => item.ProductId == productId);
        }
        public async Task<Product> PostAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> PutAsync(int productId, Product product)
        {
            var getProduct = await _context.Products.FirstOrDefaultAsync(item => item.ProductId == productId);
            getProduct.ProductName = product.ProductName;
            getProduct.Description = product.Description;
            getProduct.Price = product.Price;
            getProduct.Discount = product.Discount;
            getProduct.BestSellers = product.BestSellers;
            getProduct.HomeFlag = product.HomeFlag;
            getProduct.Active = product.Active;
            getProduct.Tags = product.Tags;
            getProduct.UnitsInStock = product.UnitsInStock;
            await _context.SaveChangesAsync();
            return getProduct;
        }
        public async Task DeleteAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(item => item.ProductId == productId);
            await _context.SaveChangesAsync();
        }
    }
}
