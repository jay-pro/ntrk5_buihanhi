using ecommerceweb.API.Models;
using ecommerceweb.Website.Models;
using ecommerceweb.Website.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ecommerceweb.Website.Controllers
{
    public class ProductController : Controller
    {
        string baseUrl = "https://localhost:44303";
        public Product product = new Product();

        private readonly EcommerceWebContext _context;
        public ProductController(EcommerceWebContext context)
        {
            _context = context;
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

                HttpResponseMessage Res = await client.GetAsync("/api/Products");

                if (Res.IsSuccessStatusCode)
                {
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(ProductResponse);
                }

                return View(products);
            }
        }

        //Get a product's details
        public async Task<ActionResult> Details (int id)
        {
            //var client = new HttpClient();
            //client.BaseAddress = new Uri(baseUrl);
            //var Res = await client.GetAsync($"api/Products/{ProductId}");
            //var Result = Res.Content.ReadAsStringAsync().Result;
            //product = JsonConvert.DeserializeObject<Product>(Result);
            //return View(product);

            var client = new HttpClient();
            
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync($"/api/Products/{id}");

            var ProductResponse = Res.Content.ReadAsStringAsync().Result;
            product = JsonConvert.DeserializeObject<Product>(ProductResponse);

            /*if (Res.IsSuccessStatusCode)
            {
                var ProductResponse = Res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(ProductResponse);
            }*/
            
            return View(product);
        }
    }
}
