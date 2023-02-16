using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
