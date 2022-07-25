using AutoMapper;
using ecommerceweb.SharedModel;
using ecommerceweb.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ecommerceweb.Website.Controllers
{
    public class ProductImageController : Controller
    {
        ProductImageDTO viewProductImage = new ProductImageDTO();
        List<ProductImageDTO> viewProductImages = new List<ProductImageDTO>();
        IProductImageService productImageService = RestService.For<IProductImageService>("https://localhost:7024/api");

        public ProductImageController(IMapper mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                viewProductImages = await productImageService.GetProductImages();
                return View(viewProductImage);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ProductImageDTO productImage)
        {
            try
            {
                await productImageService.CreateProductImage(productImage);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Edit(int ProductImageId)
        {
            try
            {
                viewProductImage = await productImageService.GetProductImage(ProductImageId);
                return View(viewProductImage);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int ProductImageId, ProductImageDTO productImage)
        {
            try
            {
                await productImageService.UpdateProductImage(ProductImageId, productImage);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Delete(int ProductImageId)
        {
            try
            {
                await productImageService.DeleteProductImage(ProductImageId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ViewResult Error() => View();
    }
}
