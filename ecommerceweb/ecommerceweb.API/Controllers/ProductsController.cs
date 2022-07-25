using AutoMapper;
using ecommerceweb.API.Data;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        public ProductsController(IProductRepository product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        //Get all products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var getProducts = await _product.GetAsync();
                if (!getProducts.Any())
                {
                    return NotFound("There's no product.");
                }
                var productDTO = _mapper.Map<List<ProductDTO>>(getProducts);
                return Ok(productDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Get a product's details
        [HttpGet]
        [Route("{ProductId:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int ProductId)
        {
            try
            {
                var getProduct = await _product.GetByIdAsync(ProductId);
                if (getProduct == null)
                {
                    return NotFound("There's no product.");
                }
                var productDTO = _mapper.Map<ProductDTO>(getProduct);
                return Ok(productDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Create a product
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductDTO productDTO)
        {
            try
            {
                var createProduct = _mapper.Map<Product>(productDTO);
                var newproduct = await _product.PostAsync(createProduct);
                var returnProduct = _mapper.Map<ProductDTO>(newproduct);
                return Ok(returnProduct);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Update a product
        [HttpPut]
        [Route("{ProductId:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int ProductId, ProductDTO productDTO)
        {
            try
            {
                var createProduct = _mapper.Map<Product>(productDTO);
                var modifiedProduct = await _product.PutAsync(ProductId, createProduct);
                var returnProduct = _mapper.Map<ProductDTO>(modifiedProduct);
                return Ok(returnProduct);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Delete a product
        [HttpDelete]
        [Route("{ProductId:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int ProductId)
        {
            try
            {
                var deleteProduct = await _product.GetByIdAsync(ProductId);
                if (deleteProduct == null)
                {
                    return NotFound("There's no product.");
                }
                await _product.DeleteAsync(ProductId);
                return Ok("Deleted successfully");
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }
    }
}
