using ArtGalleryApp.Models;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtGalleryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoBLoB()
        {
            return View();
        }
        public IActionResult Testtt()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogPage()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Artists()
        {
            return View();
        }
        public IActionResult ArtistsAccount()
        {
            return View();
        }
        public IActionResult ArtistPage()
        {
            return View();
        }
        public IActionResult ArtworkPage()
        {
            return View();
        } 
         public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ArtistRegistration()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult UploadFile()
        {
            return View();
        }
        public IActionResult AdminTeam()
        {
            return View();
        }
        public IActionResult AdminArtist()
        {
            ArtistViewModel Item = new ArtistViewModel();
            return View();
        }
        public IActionResult AdminCoustomer()
        {
            return View();
        }
        public IActionResult AdminEdit()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult SigninAdmin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}