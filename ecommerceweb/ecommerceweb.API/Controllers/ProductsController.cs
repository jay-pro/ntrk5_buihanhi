using ecommerceweb.API.Data;
using ecommerceweb.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly APIDbContext _context;
        public ProductsController(APIDbContext dbContext)
        {
            this._context = dbContext;
        }

        //Admin Get all products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        //Get a product's details
        [HttpGet]
        [Route("{ProductId:int}")]//Guid
        public async Task<IActionResult> GetProduct([FromRoute] int ProductId)//Guid
        {
            var product = await _context.Products.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.ProductId == ProductId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Create a product
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductRequest addProductRequest)
        {
            var Product = new Product()
            {
                //ProductId = Guid.NewGuid(),
                //ProductId = addProductRequest.ProductId,
                ProductName = addProductRequest.ProductName,
                ShortDesc = addProductRequest.ShortDesc,
                Description = addProductRequest.Description,
                CategoryId = addProductRequest.CategoryId,
                Price = addProductRequest.Price,
                Discount = addProductRequest.Discount,
                Thumb = addProductRequest.Thumb,
                Images = addProductRequest.Images,
                CreatedDate = addProductRequest.CreatedDate,
                ModifiedDate = addProductRequest.ModifiedDate,
                BestSellers = addProductRequest.BestSellers, 
                HomeFlag = addProductRequest.HomeFlag,
                Active = addProductRequest.Active,
                Tags = addProductRequest.Tags,
                Title = addProductRequest.Title,
                Alias = addProductRequest.Alias,
                MetaDesc = addProductRequest.MetaDesc,
                MetaKey = addProductRequest.MetaKey,
                UnitsInStock = addProductRequest.UnitsInStock
            };

            await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();

            return Ok(Product);
        }

        //Update a product
        [HttpPut]
        [Route("{ProductId:int}")]//Guid
        public async Task<IActionResult> UpdateProduct([FromRoute] int ProductId, UpdateProductRequest updateProductRequest)//Guid
        {
            var Product = await _context.Products.FindAsync(ProductId);
            if (Product != null)
            {
                Product.ProductName = updateProductRequest.ProductName;
                Product.ProductName = updateProductRequest.ProductName;
                Product.ShortDesc = updateProductRequest.ShortDesc;
                Product.Description = updateProductRequest.Description;
                Product.CategoryId = updateProductRequest.CategoryId;
                Product.Price = updateProductRequest.Price;
                Product.Discount = updateProductRequest.Discount;
                Product.Thumb = updateProductRequest.Thumb;
                Product.Images = updateProductRequest.Images;
                Product.CreatedDate = updateProductRequest.CreatedDate;
                Product.ModifiedDate = updateProductRequest.ModifiedDate;
                Product.BestSellers = updateProductRequest.BestSellers;
                Product.HomeFlag = updateProductRequest.HomeFlag;
                Product.Active = updateProductRequest.Active;
                Product.Tags = updateProductRequest.Tags;
                Product.Title = updateProductRequest.Title;
                Product.Alias = updateProductRequest.Alias;
                Product.MetaDesc = updateProductRequest.MetaDesc;
                Product.MetaKey = updateProductRequest.MetaKey;
                Product.UnitsInStock = updateProductRequest.UnitsInStock;

                await _context.SaveChangesAsync();
                return Ok(Product);
            }
            return NotFound();
        }

        //Delete a product
        [HttpDelete]
        [Route("{ProductId:int}")]//Guid
        public async Task<IActionResult> DeleteProduct([FromRoute] int ProductId)//Guid
        {
            var product = await _context.Products.FindAsync(ProductId);
            if(product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }
    }
}
