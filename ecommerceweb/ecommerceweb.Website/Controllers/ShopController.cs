using ecommerceweb.SharedModel;
using ecommerceweb.SharedModel.Enums;
using ecommerceweb.Website.Models;
using ecommerceweb.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json.Serialization;


namespace ecommerceweb.Website.Controllers
{
    public class ShopController : Controller
    {
        ProductDTO viewProduct = new ProductDTO();
        RatingDTO rating = new RatingDTO();
        List<ProductDTO> viewProducts = new List<ProductDTO>();
        List<CategoryDTO> viewCategories = new List<CategoryDTO>();
        IProductService productService = RestService.For<IProductService>("https://localhost:44303/api");
        ICategoryService categoryService = RestService.For<ICategoryService>("https://localhost:44303/api");
        IRatingService ratingService = RestService.For<IRatingService>("https://localhost:7024/api");

        private readonly ILogger<HomeController> _logger;

        public async Task<IActionResult> Index()
        {
            try
            {
                MultiModels customModel = new MultiModels();
                /*customModel.Products = await productService.GetProducts();
                customModel.Categories = await categoryService.GetCategories();*/

                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Detail(int ProductId)
        {
            try
            {
                MultiModels customModel = new MultiModels();
                customModel.Product = await productService.GetProduct(ProductId);
                /*customModel.Product = await productService.GetProduct(ProductId);
                customModel.Products = await productService.GetProducts();*/
                var ratings = await ratingService.GetRatingsByProductId(ProductId);
                if (ratings.Count() > 0)
                {
                    var ratingSum = ratings.Sum(d => d.Stars);
                    ViewBag.RatingSum = ratingSum;
                    var ratingCount = ratings.Count();
                    ViewBag.RatingCount = ratingCount;
                }
                else
                {
                    ViewBag.RatingSum = 0;
                    ViewBag.RatingCount = 0;
                }
                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Category(int CategoryId)
        {
            try
            {
                MultiModels customModel = new MultiModels();
                customModel.Category = await categoryService.GetCategory(CategoryId);
                /*customModel.Category = await categoryService.GetCategory(CategoryId);
                customModel.Categories = await categoryService.GetCategories();*/
                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        /*[ecommerceweb.API.Authorization.Authorization(AccountRole.Customer)]*/
        public async Task<IActionResult> Rating(int ProductId)
        {
            try
            {
                MultiModels customModel = new MultiModels();
                customModel.Product = await productService.GetProduct(ProductId);
                /*customModel.Product = await productService.GetProduct(ProductId);
                customModel.Ratings = await ratingService.GetRatingsByProductId(ProductId);*/
                var ratings = await ratingService.GetRatingsByProductId(ProductId);
                if (ratings.Count() > 0)
                {
                    var ratingSum = ratings.Sum(d => d.Stars);
                    ViewBag.RatingSum = ratingSum;
                    var ratingCount = ratings.Count();
                    ViewBag.RatingCount = ratingCount;
                }
                else
                {
                    ViewBag.RatingSum = 0;
                    ViewBag.RatingCount = 0;
                }
                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rating(int Stars, int ProductId)
        {
            try
            {
                rating.ProductId = ProductId;
                rating.Stars = Stars;
                await ratingService.CreateRating(rating);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
    }
}
