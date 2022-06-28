using ecommerceweb.API.Data;
using ecommerceweb.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly APIDbContext dbContext;
        public CategoriesController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(dbContext.Categories.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCategory([FromRoute] Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(AddCategoryRequest addCategoryRequest)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = addCategoryRequest.CategoryName,
                Description = addCategoryRequest.Description
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return Ok(category);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, UpdateCategoryRequest updateCategoryRequest)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if(category != null)
            {
                category.CategoryName = updateCategoryRequest.CategoryName;
                category.Description = updateCategoryRequest.Description;
                category.Images = updateCategoryRequest.Images;

                await dbContext.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var Category = await dbContext.Categories.FindAsync(id);
            if (Category != null)
            {
                dbContext.Remove(Category);
                await dbContext.SaveChangesAsync();
                return Ok(Category);
            }
            return NotFound();
        }
    }
}
