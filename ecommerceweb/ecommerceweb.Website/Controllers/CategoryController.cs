using ecommerceweb.Website.Models;
using ecommerceweb.Website.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ecommerceweb.Website.Controllers
{
    public class CategoryController : Controller
    {
        string baseUrl = "https://localhost:44303";

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        //Get all categories
        public async Task<ActionResult> Index()
        {
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
        }
    }
}
