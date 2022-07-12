using Microsoft.AspNetCore.Mvc;

namespace ecommerceweb.Website.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
