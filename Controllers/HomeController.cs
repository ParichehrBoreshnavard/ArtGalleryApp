using ArtGalleryApp.Context;
using ArtGalleryApp.Models;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;

namespace ArtGalleryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly dbSarvContext dbSarv;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, dbSarvContext _dbSarv, IWebHostEnvironment _webHostEnvironment)
        {
            _logger = logger;
            dbSarv = _dbSarv;
            webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Basket()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult ArtistAdminnn()
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
            Contact newMessage = new Contact();

            dbSarv.Contacts.Add(newMessage);
            newMessage.Name = contactViewModel.Name;
            newMessage.Email = contactViewModel.Email.ToString();
            newMessage.Subject = contactViewModel.Subject;
            newMessage.Body = contactViewModel.Body;

            dbSarv.SaveChanges();
            return Redirect("/Home/Contact");

        }
        public IActionResult ArtistRegistration()
        {
            ArtistRegistrationViewModel model = new ArtistRegistrationViewModel();
            model.lstArtistField = dbSarv.ArtistField_.ToList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArtistRegistration(ArtistRegistrationViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "There is an error in record information";
            //    return View();
            //}
            User? artist = new User();
            if (artist != null)
            {
                dbSarv.Users.Add(artist);
                artist.FirstName = model.FirstName;
                artist.LastName = model.LastName;
                artist.Description = model.Description;
                artist.Country = model.Country;
                artist.YearOfBirth = model.YearOfBirth;
                artist.Email = model.Email;
                artist.Phone = model.Phone;
                artist.Password = model.Password;
                artist.PortfolioUrl = model.PortfolioUrl;
                artist.ArtistField_ = dbSarv.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                if (model.UploadImgUrl != null)
                    artist.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Artist");

                RoleUser roleUser = new RoleUser();
                dbSarv.RoleUser.Add(roleUser);
                roleUser.User_ = artist;
                roleUser.Role_ = dbSarv.Rols.First(s => s.Id == RoleValues.Artist);

                dbSarv.SaveChanges();
            }
            return Redirect("/Profile");


        }
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signin(SigninViewModel model)
        {
            User? user = dbSarv.Users.FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);
            if (user != null)
            {
                LoginUser(user.Id);
                return Redirect("/Profile");
            }
            ViewBag.Error = "Email or Password incorrect.";
            return View();
        }

        private void LoginUser(int id)
        {
            HttpContext.Session.SetInt32("artGalleryuserid", id);
         
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
                ViewBag.Error = "There is an error in record information";
                return View();
            }
            User newAccount = new User();
            dbSarv.Users.Add(newAccount);
            newAccount.Email = signupViewModel.Email;
            newAccount.FirstName = signupViewModel.FirstName;
            newAccount.LastName = signupViewModel.LastName;
            newAccount.Password = signupViewModel.Password;
            newAccount.Phone = signupViewModel.Phone;
            RoleUser userRole = new RoleUser();
            userRole.User_ = newAccount;
            userRole.Role_ = dbSarv.Rols.First(r => r.Id == RoleValues.Customer);
            dbSarv.RoleUser.Add(userRole);
            dbSarv.SaveChanges();
            return Redirect("/Profile");

        }

        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Gallery(GalleryViewModel galleryViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "There is an error in record information";
            //    return View();
            //}
            Gallery newArtwork = new Gallery();

            //dbSarv.Gallery.Add(newArtwork);
            //newArtwork.Description = galleryViewModel.Description;
            //newArtwork.UploadDate = galleryViewModel.UploadDate;
            //newArtwork.ProduceDate = galleryViewModel.ProduceDate;
            //newArtwork.Availability = galleryViewModel.Availability;
            //newArtwork.Inventory = (int)galleryViewModel.Inventory;
            //newArtwork.Price = galleryViewModel.Price;
            //newArtwork.artworkField = galleryViewModel.artworkField;
            //newArtwork.SoldDate = (DateTime)galleryViewModel.SoldDate;
            //newArtwork.medium=galleryViewModel.medium;
            //newArtwork.Size = galleryViewModel.Size;
            //newArtwork.style = galleryViewModel.style;
            //newArtwork.ImgUrl = galleryViewModel.ImgUrl;


            dbSarv.SaveChanges();
            return Redirect("/Home/Gallery");

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
            ArtistsViewModel item = new ArtistsViewModel();
            return View(item);
        }
        [HttpPost]
        public IActionResult AdminEditArtist(ArtistsViewModel item)
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
            //Gallery newArtPiece = new();
            //dbSarv.Gallery.Add(newArtPiece);
            //newArtPiece.Artist= uploadFileViewModel.Artist_.ToString();
            //newArtPiece.style = uploadFileViewModel.Style_.ToString(); 
            //newArtPiece.ProduceDate= uploadFileViewModel.ProduceDate;
            //newArtPiece.UploadDate= uploadFileViewModel.UploadDate;
            //newArtPiece.SoldDate = uploadFileViewModel.SoldDate;
            //newArtPiece.ImgUrl = uploadFileViewModel.ImgUrl;
            //newArtPiece.Availability = uploadFileViewModel.Availability;
            //newArtPiece.Price = uploadFileViewModel.Price.ToString(); 
            //newArtPiece.artworkField= uploadFileViewModel.ArtworkField_.ToString();
            //newArtPiece.Description = uploadFileViewModel.Description;
            //TagGallery artworkTag = new TagGallery();
            //artworkTag.Gallery_ = newArtPiece;
            //artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Medium);
            //artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Field);
            //artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Style);
            //artworkTag.Tag_ = dbSarv.Tags.First(r => r.Id == TagValues.Size);
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
        public async Task<string> UploadImg(IFormFile formFile, string directoryName, string name = "")
        {

            string ImgUrl = "";
            string extention = Path.GetExtension(formFile.FileName);
            string filename = directoryName + name + DateTime.Now.ToString("yymmssfff") + extention;
            string path = Path.Combine(webHostEnvironment.WebRootPath + "/AdminAssessts/" + directoryName + "/", filename);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
                ImgUrl = "/AdminAssessts/" + directoryName + "/" + filename;
            }
            return ImgUrl;
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