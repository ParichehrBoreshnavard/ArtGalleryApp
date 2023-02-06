using ArtGalleryApp.Context;
using ArtGalleryApp.Models;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;

namespace ArtGalleryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbSarvContext dbSarv;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,dbSarvContext _dbSarv)
        {
            _logger = logger;
            dbSarv = _dbSarv;
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
        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "There is an error in record information";
            //    return View();
            //}
            Contact newMessage = new Contact ();
            dbSarv.Contacts.Add(newMessage);
            newMessage.Name = contactViewModel.Name;
            newMessage.Email = contactViewModel.Email.ToString();
            newMessage.Subject= contactViewModel.Subject;
            newMessage.Body = contactViewModel.Body;
            Contact contact = new Contact();
            dbSarv.Contacts.Add(contact);
            dbSarv.SaveChanges();
            return Redirect("Contact");

        }
        public IActionResult ArtistRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ArtistRegistration(ArtistRegistrationViewModel artistRegistrationViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "There is an error in record information";
            //    return View();
            //}
            User newAccount = new User();
            dbSarv.Users.Add(newAccount);
            newAccount.Email = artistRegistrationViewModel.Email.ToString();
            newAccount.FirstName = artistRegistrationViewModel.FirstName;
            newAccount.LastName = artistRegistrationViewModel.LastName;
            newAccount.YearOfBirth = artistRegistrationViewModel.YearOfBirth;
            newAccount.Country = artistRegistrationViewModel.Country;
            newAccount.Field_ = artistRegistrationViewModel.Field_;
            newAccount.ImgUrl = artistRegistrationViewModel.ImgUrl;
            newAccount.PortfolioUrl = artistRegistrationViewModel.PortfolioUrl;
            newAccount.Password = artistRegistrationViewModel.Password;
            newAccount.Phone = artistRegistrationViewModel.Phone;
            newAccount.Description = artistRegistrationViewModel.Description;
            RoleUser userRole = new RoleUser();
            userRole.User_ = newAccount;
            userRole.Role_ = dbSarv.Rols.First(r => r.Id == RoleValues.Artist);
            dbSarv.RoleUser.Add(userRole);
            dbSarv.SaveChanges();
            return Redirect("/home/AdminArtist");

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
            if (!ModelState.IsValid)
            {
                ViewBag.Error="There is an error in record information";
                return View();
            }
            User newAccount = new User();
            dbSarv.Users.Add(newAccount);
            newAccount.Email = signupViewModel.Email;
            newAccount.FirstName= signupViewModel.FirstName;
            newAccount.LastName= signupViewModel.LastName;
            newAccount.Password= signupViewModel.Password;
            newAccount.Phone = signupViewModel.Phone;
            RoleUser userRole= new RoleUser();
            userRole.User_= newAccount;
            userRole.Role_ = dbSarv.Rols.First(r => r.Id == RoleValues.Customer);
            dbSarv.RoleUser.Add(userRole);
            dbSarv.SaveChanges();
            return Redirect("/home/AdminCustomer");

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
            UploadFileViewModel item = new UploadFileViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult UploadFile(UploadFileViewModel uploadFileViewModel)
        {
            if (!ModelState.IsValid)
           {
              ViewBag.Error = "There is an error in record information";
              return View();
            }
            Gallery newArtPiece = new();
            dbSarv.Gallery.Add(newArtPiece);
            newArtPiece.Artist= uploadFileViewModel.Artist_.ToString();
            newArtPiece.Style = uploadFileViewModel.Style_.ToString(); 
            newArtPiece.ProduceDate= uploadFileViewModel.ProduceDate;
            newArtPiece.UploadDate= uploadFileViewModel.UploadDate;
            newArtPiece.SoldDate = uploadFileViewModel.SoldDate;
            newArtPiece.ImgUrl = uploadFileViewModel.ImgUrl;
            newArtPiece.Availability = uploadFileViewModel.Availability;
            newArtPiece.Price = uploadFileViewModel.Price.ToString(); 
            newArtPiece.Field= uploadFileViewModel.Field_.ToString();
            newArtPiece.Description = uploadFileViewModel.Description;
            TagGallery artworkTag = new TagGallery();
            artworkTag.Gallery_ = newArtPiece;
            artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Medium);
            artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Field);
            artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Style);
            artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Size);
            //dbSarv.TagGallery.Add(artgalleryTag);
            dbSarv.SaveChanges();
            return Redirect("/home/AdminGallery");

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
        public IActionResult AdminEvent_1()
        {
            return View();
        }
        public IActionResult AdminStartPage()
        {
            return View();
        }
        public IActionResult ArtistField()
        {
            return View();
        }
        public IActionResult ArtworkField()
        {
            return View();
        }
        public IActionResult Style()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Style(StyleViewModel styleViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "There is an error in record information";
            //    return View();
            //}
            Style newArtStyle = new Style();
            dbSarv.Styles.Add(newArtStyle);
            styleViewModel.Name = styleViewModel.Name;
            
            dbSarv.SaveChanges();
            return Redirect("/home/Style");

        }
        
          
          
        public IActionResult Medium()
        {
            return View();
        }
        public IActionResult Size()
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