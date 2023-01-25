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
        [HttpPost]
        public IActionResult Signup(SignupViewModel signupViewModel)
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
        public IActionResult AdminEditTeam()
        {
            TeamViewModel item = new TeamViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult AdminEditTeam(TeamViewModel item)
        {
            return View(item);
        }
        
        public IActionResult AdminArtist()
        {
         
            return View();
        }
        public IActionResult AdminEditCustomer()
        {
            CustomerViewModel item = new CustomerViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult AdminEditCustomer(CustomerViewModel item)
        {
            return View(item);
        }
        public IActionResult AdminCustomer()
        {
           return View();
        }
     
    public IActionResult AdminEditArtist()
        {
            ArtistViewModel item = new ArtistViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult AdminEditArtist(ArtistViewModel item)
        {
            return View(item);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult SigninAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignupAdmin(SignupViewModel item)
        {
            return View(item);
        }
        public IActionResult ForgetPassword()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult SigninAdmin(SigninViewModel item)
        {
            return View(item);
        }
        public IActionResult AdminGallery()
        {
            return View(); 
        }
        public IActionResult AdminEditGallery()
        {
            GalleryViewModel item = new GalleryViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult AdminEditGallery(GalleryViewModel item)
        {
            return View(item);
        }

        public IActionResult AdminBlog()
        {
            return View();
        }
        public IActionResult AdminEditBlog()
        {
            BlogViewModel item = new BlogViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult AdminEditBlog(BlogViewModel item)
        {
            return View(item);
        }
        public IActionResult Basket()
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