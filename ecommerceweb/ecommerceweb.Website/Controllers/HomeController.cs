using ecommerceweb.API.Interfaces;
using ecommerceweb.SharedModel;
using ecommerceweb.SharedModel.Authenticate;
using ecommerceweb.SharedModel.Enums;
using ecommerceweb.Website.Models;
using ecommerceweb.Website.Models.Context;
using ecommerceweb.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ecommerceweb.Website.Controllers
{
    public class HomeController : Controller
    {
        //string baseUrl = "https://localhost:44303/api";
        ProductDTO viewProduct = new ProductDTO();
        List<ProductDTO> viewProducts = new List<ProductDTO>();
        IProductService productService = RestService.For<IProductService>("https://localhost:44303/api");
        private readonly ILogger<HomeController> _logger;
        private IAuthenticateService _service;

        public HomeController()
        {
            // _service = service;
            ViewData["title"] = "HOme";
            ViewData["Message"] = "welcome to ASp";
           
        }

        //public IActionResult Login() => View();
        /*[AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AuthenticateRequestDTO authenticateRequest)
        {
        }*/

        public IActionResult ProductImage()
        {
            return View();
        }       

        //Get all categories
        public async Task<ActionResult> Index()
        {
            try
            {
                viewProducts = await productService.GetProducts();
                return View(viewProducts);
            }
            catch
            {
                return RedirectToAction("Error");
            }
            /*
            List<Category> categories = new List<Category>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("/api/Categories");

                if (Res.IsSuccessStatusCode)
                {
                    var CategoryResponse = Res.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<List<Category>>(CategoryResponse);
                }

                return View(categories);
            }
            */
        }

        /*[ecommerceweb.API.Authorization.Authorization(AccountRole.Customer)]
        [Route("index")]
        [HttpGet]*/

        public IActionResult Privacy()
        {
            return View();
        }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        /* public IActionResult Index()
            {
                return View();
            }*/

        /*public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

    }
}