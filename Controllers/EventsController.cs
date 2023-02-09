using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
