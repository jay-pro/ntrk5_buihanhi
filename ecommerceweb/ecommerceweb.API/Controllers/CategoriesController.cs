using AutoMapper;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;//
using ecommerceweb.API.Data;//
using Microsoft.EntityFrameworkCore;//

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _category;

        public CategoriesController(ICategoryRepository category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        //Get all categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var getCategories = await _category.GetAsync();
                if (!getCategories.Any())
                {
                    return NotFound("There's no category.");
                }
                var categoryDTO = _mapper.Map<List<CategoryDTO>>(getCategories);
                return Ok(categoryDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Get a category's details
        [HttpGet]
        [Route("{CategoryId:int}")]
        public async Task<IActionResult> GetCategory([FromRoute] int CategoryId)
        {
            try
            {
                var getCategory = await _category.GetByIdAsync(CategoryId);
                if (getCategory == null)
                {
                    return NotFound("There's no category.");
                }
                var categoryDTO = _mapper.Map<CategoryDTO>(getCategory);
                return Ok(categoryDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Create a category
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var createCategory = _mapper.Map<Category>(categoryDTO);
                var newcategory = await _category.PostAsync(createCategory);
                var returnCategory = _mapper.Map<CategoryDTO>(newcategory);
                return Ok(returnCategory);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Update a category
        [HttpPut]
        [Route("{CategoryId:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int CategoryId, CategoryDTO categoryDTO)
        {
            try
            {
                var updateCategory = _mapper.Map<Category>(categoryDTO);
                var modifiedCategory = await _category.PutAsync(CategoryId, updateCategory);
                var returnCategory = _mapper.Map<CategoryDTO>(modifiedCategory);
                return Ok(returnCategory);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Delete a category
        [HttpDelete]
        [Route("{CategoryId:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId)
        {
            try
            {
                var deleteCategory = await _category.GetByIdAsync(CategoryId);
                if (deleteCategory == null)
                {
                    return NotFound("There's no category.");
                }
                await _category.DeleteAsync(CategoryId);
                return Ok("Deleted successfully.");
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }
    }
}
