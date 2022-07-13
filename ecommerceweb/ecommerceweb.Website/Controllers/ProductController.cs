using ecommerceweb.Website.Models;
using ecommerceweb.Website.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ecommerceweb.Website.Controllers
{
    public class ProductController : Controller
    {
        string baseUrl = "https://localhost:44303";

        private readonly ILogger<ProductController> _logger;

        //private readonly EcommerceWebContext _context;

        /*public ProductController(EcommerceWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }*/

        /*public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }*/

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        //Get all products
        public async Task<ActionResult> Index()
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("/api/products");

                if (Res.IsSuccessStatusCode)
                {
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(ProductResponse);
                }

                return View(products);
            }
        }
    }
}
