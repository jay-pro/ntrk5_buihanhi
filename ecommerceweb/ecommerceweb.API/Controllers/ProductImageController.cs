using AutoMapper;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _image;
        public static IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(IProductImageRepository image, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _image = image;
            _webHostEnvironment = webHostEnvironment;
        }

        //Get all images
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            try
            {
                var getImages = await _image.GetAsync();
                var imageDTO = _mapper.Map<List<ProductImageDTO>>(getImages);
                if (!imageDTO.Any())
                {
                    return NotFound("There's no product image.");
                }
                return Ok(imageDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Get 1 image
        [HttpGet("{ProductImageId}")]
        public async Task<IActionResult> GetImage(int ProductImageId)
        {
            try
            {
                var getImage = await _image.GetByIdAsync(ProductImageId);
                if (getImage == null)
                {
                    return NotFound("There's no product image.");
                }
                var imageDTO = _mapper.Map<ProductImageDTO>(getImage);
                var imgLink = _webHostEnvironment.WebRootPath + "\\uploads\\" + imageDTO.ImageName;
                if (System.IO.File.Exists(imgLink))
                {
                    byte[] b = System.IO.File.ReadAllBytes(imgLink);
                    return File(b, "image/png");
                }
                return Ok(imageDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Generate 1 image
        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] ProductImageDTO image)
        {
            var baseUrl = "https://localhost:44303/api/ProductImage";
            try
            {
                if(image.File.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    string fileUrl = _webHostEnvironment.WebRootPath + "\\uploads\\" + image.File.FileName;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fs = System.IO.File.Create(path + image.File.FileName))
                    {
                        image.File.CopyTo(fs);
                        fs.Flush();
                        image.ImageName = image.File.FileName;
                        image.ImageUrl = baseUrl;

                        var createImage = _mapper.Map<ProductImage>(image);
                        var newImage = await _image.PostAsync(createImage);
                        var returnImage = _mapper.Map<ProductImageDTO>(newImage);

                        return Ok(returnImage);
                    }
                }
                else
                {
                    return BadRequest("Ooops.");
                }
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Update 1 image
        [HttpPut("{ProductImageId}")]
        public async Task<IActionResult> PutImage(int ProductImageId, [FromForm]ProductImageDTO image)
        {
            var baseUrl = "https://localhost:44303/api/ProductImage";
            try
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                string fileUrl = _webHostEnvironment.WebRootPath + "\\uploads\\" + image.File.FileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fs = System.IO.File.Create(path + image.File.FileName))
                {
                    image.File.CopyTo(fs);
                    fs.Flush();
                    image.ImageName = image.File.FileName;
                    image.ImageUrl = baseUrl;

                    var putImage = _mapper.Map<ProductImage>(image);
                    var modifiedImage = await _image.PutAsync(ProductImageId, putImage);
                    var returnImage = _mapper.Map<ProductImageDTO>(modifiedImage);
                    return Ok(returnImage);
                }
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Delete 1 image
        [HttpDelete("{ProductImageId}")]
        public async Task<IActionResult> DeleteImage(int ProductImageId)
        {
            try
            {
                var deleteImage = await _image.GetByIdAsync(ProductImageId);
                if (deleteImage == null)
                {
                    return NotFound("There's no product image.");
                }
                await _image.DeleteAsync(ProductImageId);
                return Ok("Deleted successfully");
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        public class ProductImageModel
        {
            public int ProductImageId { get; set; }
            /*[ForeignKey("Product")]*/
            public int ProductId { get; set; }
            public string ImageName { get; set; }
            public string ImageUrl { get; set; }
           /* public virtual Product Product { get; set; }*/
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
