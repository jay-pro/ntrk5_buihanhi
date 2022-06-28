using ecommerceweb.API.Data;
using ecommerceweb.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly APIDbContext dbContext;
        public ProductsController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(dbContext.Products.ToList());
        }

        //Create a product
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductRequest addProductRequest)
        {
            var Product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = addProductRequest.ProductName,
                Description = addProductRequest.Description,
                Ratings = addProductRequest.Ratings,
                Price = addProductRequest.Price,
                Images = addProductRequest.Images,
                CreatedDate = addProductRequest.CreatedDate,
                SoldsNumb = addProductRequest.SoldsNumb,
                WarehousesNumb = addProductRequest.WarehousesNumb
            };

            await dbContext.Products.AddAsync(Product);
            await dbContext.SaveChangesAsync();

            return Ok(Product);
        }

        //Update a product
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductRequest updateProductRequest)
        {
            var Product = await dbContext.Products.FindAsync(id);
            if (Product != null)
            {
                Product.ProductName = updateProductRequest.ProductName;
                Product.Description = updateProductRequest.Description;
                Product.Ratings = updateProductRequest.Ratings;
                Product.Price = updateProductRequest.Price;
                Product.Images = updateProductRequest.Images;
                Product.CreatedDate = updateProductRequest.CreatedDate;
                Product.SoldsNumb = updateProductRequest.SoldsNumb;
                Product.WarehousesNumb = updateProductRequest.WarehousesNumb;

                await dbContext.SaveChangesAsync();
                return Ok(Product);
            }
            return NotFound();
        }

        //Get a product's details
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if(product != null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Delete a product
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if(product != null)
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }
    }
}
