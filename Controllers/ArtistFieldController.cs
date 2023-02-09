using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class ArtistFieldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
