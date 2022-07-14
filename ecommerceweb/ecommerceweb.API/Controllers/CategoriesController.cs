using ecommerceweb.API.Data;
using ecommerceweb.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //Get all categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }

        //Get a category's details
        [HttpGet]
        [Route("{CategoryId:int}")]//Guid
        public async Task<IActionResult> GetCategory([FromRoute] int CategoryId)//Guid
        {
            var category = await dbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.CategoryId == CategoryId);
            if (category == null)//!=
            {
                return NotFound();
            }
            return Ok(category);
        }

        //Create a category
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(AddCategoryRequest addCategoryRequest)
        {
            var category = new Category()
            {
                //CategoryId = Guid.NewGuid(),
                //CategoryId = addCategoryRequest.CategoryId,
                CategoryName = addCategoryRequest.CategoryName,
                Description = addCategoryRequest.Description,
                ParentId = addCategoryRequest.ParentId,
                Levels = addCategoryRequest.Levels,
                Ordering = addCategoryRequest.Ordering,
                Published = addCategoryRequest.Published,
                Thumb = addCategoryRequest.Thumb,
                Title = addCategoryRequest.Title,
                Alias = addCategoryRequest.Alias,
                MetaDesc = addCategoryRequest.MetaDesc,
                MetaKey = addCategoryRequest.MetaKey,
                Cover = addCategoryRequest.Cover,
                SchemaMarkup = addCategoryRequest.SchemaMarkup
                //,Images = addCategoryRequest.Images
            };
            if(category.CategoryName ==" ")
            {
                return NotFound();
            }

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return Ok(category);
        }


        [HttpPut]
        [Route("{CategoryId:int}")]//Guid
        public async Task<IActionResult> UpdateCategory([FromRoute] int CategoryId, UpdateCategoryRequest updateCategoryRequest)//Guid
        {
            var category = await dbContext.Categories.FindAsync(CategoryId);
            if(category != null)
            {
                category.CategoryName = updateCategoryRequest.CategoryName;
                category.Description = updateCategoryRequest.Description;
                category.ParentId = updateCategoryRequest.ParentId;
                category.Levels = updateCategoryRequest.Levels;
                category.Ordering = updateCategoryRequest.Ordering;
                category.Published = updateCategoryRequest.Published;
                category.Thumb = updateCategoryRequest.Thumb;
                category.Title = updateCategoryRequest.Title;
                category.Alias = updateCategoryRequest.Alias;
                category.MetaDesc = updateCategoryRequest.MetaDesc;
                category.MetaKey = updateCategoryRequest.MetaKey;
                category.Cover = updateCategoryRequest.Cover;
                category.SchemaMarkup = updateCategoryRequest.SchemaMarkup;
                //,Images = addCategoryRequest.Images;

                await dbContext.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{CategoryId:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId)//Guid
        {
            var Category = await dbContext.Categories.FindAsync(CategoryId);
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
