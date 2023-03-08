using ArtGalleryApp.Context;
using ArtGalleryApp.Models;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            SiteHomeViewModel model = new SiteHomeViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            model.about = dbSarv.About.Select(s => new AboutViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImgUrl = s.ImgUrl

            }).ToList().FirstOrDefault();
            if (model.about == null)
            {
                model.about = new AboutViewModel();
            }
            model.lstGallery = dbSarv.Gallery
            .Include(s => s.artworkField)
            .Include(s => s.medium)
            .Include(s => s.style)
            .Include(s => s.Artist)
            .OrderByDescending(s => s.UploadDate).Take(6)
            .ToList().Select(s => new GalleryUpdateViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Subject = s.Subject,
                Artist = s.Artist.FirstName + " " + s.Artist.LastName,
                artistid = s.Artist.Id,
                ProduceYear = s.ProduceDate,
                ProduceDate = s.ProduceDate,
                Size = s.Size,
                SoldDate = s.SoldDate,
                Price = s.Price,

                PublishDate = s.PublishDate,
                UploadDate = s.UploadDate,
                Inventory = s.Inventory,
                Description = s.Description,
                ImgUrl = s.ImgUrl,
                StyleId = s.style.Id,
                StyleName = s.style.Name,
                MediumId = s.medium.Id,
                MediumName = s.medium.Name,
                ArtworkFieldId = s.artworkField.Id,
                ArtworkFieldName = s.artworkField.Name,

            }).ToList();
            model.lstTeam = dbSarv.Users.Include(s => s.ArtistField_)
            .Include(s => s.TeamMembers)
            .Where(s => s.TeamMembers.Any(t => t.User_.Id == s.Id))
            .ToList().Select(s => new CustomerUpdateViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Description = s.Description,
                PortfolioUrl = s.PortfolioUrl,
                Country = s.Country,
                ImgUrl = s.ImgUrl,
                YearOfBirth = s.YearOfBirth,
                Email = s.Email,
                Phone = s.Phone,
                ArtistFieldId = s.ArtistField_ == null ? (int?)null : s.ArtistField_.Id,
                ArtistFieldName = s.ArtistField_ == null ? ("") : s.ArtistField_.Name,

            }).ToList();

            model.lstBanners = dbSarv.Banners.Include(s => s.Event_)
                .Where(s => s.PublishStartDate <= DateTime.Now
                &&
                (s.PublishEndDate == null || s.PublishEndDate >= DateTime.Now)
                )
                .Select(s => new BannersUpdateViewModel
                {
                    Id = s.Id,
                    ImgUrl = s.ImgUrl,
                    SubDescription = s.SubDescription,
                    EventTitle = s.Event_ == null ? "" : s.Event_.Title,
                    EndEventDateTime = s.Event_ == null ? null : s.Event_.EndDate,
                    StartEventDateTime = s.Event_ == null ? null : s.Event_.StartDate,
                    PublishEndDate = s.PublishEndDate,
                    PublishStartDate = s.PublishStartDate,
                    Title = s.Event_ == null ? s.Title : s.Event_.Title,
                    EventId = s.Event_ == null ? null : s.Event_.Id
                }).ToList();
            return View(model);
        }

        private List<BannersUpdateViewModel> getMenuList()
        {
            return dbSarv.Banners.Include(s => s.Event_)
                .Where(s =>
                s.Event_ != null
                &&
                s.PublishStartDate <= DateTime.Now
                &&
                (s.PublishEndDate == null || s.PublishEndDate >= DateTime.Now)
                )
                .Select(s => new BannersUpdateViewModel
                {
                    Id = s.Id,
                    ImgUrl = s.ImgUrl,
                    SubDescription = s.SubDescription,
                    EventTitle = s.Event_ == null ? "" : s.Event_.Title,
                    EndEventDateTime = s.Event_ == null ? null : s.Event_.EndDate,
                    StartEventDateTime = s.Event_ == null ? null : s.Event_.StartDate,
                    PublishEndDate = s.PublishEndDate,
                    PublishStartDate = s.PublishStartDate,
                    Title = s.Event_ == null ? s.Title : s.Event_.Title,
                    EventId = s.Event_ == null ? null : s.Event_.Id
                }).ToList();
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
        //public IActionResult Events()
        //{
        //    return View();
        //}
        public IActionResult Events(int Id)
        {
            SiteArtistViewModel model = new SiteArtistViewModel();
            return View();
        }
        public IActionResult Artists()
        {
            SiteArtistsViewModel model= new SiteArtistsViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            model.artists = dbSarv.Users.Include(s => s.ArtistField_)
            .Include(s => s.RoleUsers)
            .Where(s => s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Artist))
            .ToList().Select(s => new CustomerUpdateViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Description = s.Description,
                PortfolioUrl = s.PortfolioUrl,
                Country = s.Country,
                ImgUrl = s.ImgUrl,
                YearOfBirth = s.YearOfBirth,
                Email = s.Email,
                Phone = s.Phone,
                ArtistFieldId = s.ArtistField_ == null ? (int?)null : s.ArtistField_.Id,
                ArtistFieldName = s.ArtistField_ == null ? ("") : s.ArtistField_.Name,

            }).ToList();

            model.alphabete = new List<string>();
            model.alphabete.Add("A"); model.alphabete.Add("B"); model.alphabete.Add("C");
            model.alphabete.Add("D"); model.alphabete.Add("E"); model.alphabete.Add("F");
            model.alphabete.Add("G"); model.alphabete.Add("H"); model.alphabete.Add("I");
            model.alphabete.Add("J"); model.alphabete.Add("K"); model.alphabete.Add("L");
            model.alphabete.Add("M"); model.alphabete.Add("N"); model.alphabete.Add("O");
            model.alphabete.Add("P"); model.alphabete.Add("Q"); model.alphabete.Add("R");
            model.alphabete.Add("S"); model.alphabete.Add("T"); model.alphabete.Add("W");
            model.alphabete.Add("X"); model.alphabete.Add("Y");model.alphabete.Add("Z");
            return View(model);
        }
        public IActionResult ArtistsAccount()
        {
            return View();
        }
        public IActionResult ArtistPage(int Id)
        {
            SiteArtistViewModel model = new SiteArtistViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            var obj = dbSarv.Users.Include(s => s.ArtistField_)
            .Include(s => s.RoleUsers)
            .Where(s => s.Id == Id && s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Artist))
            .ToList().Select(s => new CustomerUpdateViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Description = s.Description,
                PortfolioUrl = s.PortfolioUrl,
                Country = s.Country,
                ImgUrl = s.ImgUrl,
                YearOfBirth = s.YearOfBirth,
                Email = s.Email,
                Phone = s.Phone,
                ArtistFieldId = s.ArtistField_ == null ? (int?)null : s.ArtistField_.Id,
                ArtistFieldName = s.ArtistField_ == null ? ("") : s.ArtistField_.Name,

            }).ToList().FirstOrDefault();
            if (obj == null)
                return Redirect("/");
            model.artist = obj;
            model.lstGallery = dbSarv.Gallery
            .Include(s => s.artworkField)
            .Include(s => s.medium)
            .Include(s => s.style)
            .Include(s => s.Artist)
            .Where(s => s.Artist.Id == Id)
            .OrderByDescending(s => s.UploadDate)
            .ToList().Select(s => new GalleryUpdateViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Subject = s.Subject,
                Artist = s.Artist.FirstName + " " + s.Artist.LastName,
                artistid = s.Artist.Id,
                ProduceYear = s.ProduceDate,
                ProduceDate = s.ProduceDate,
                Size = s.Size,
                SoldDate = s.SoldDate,
                Price = s.Price,

                PublishDate = s.PublishDate,
                UploadDate = s.UploadDate,
                Inventory = s.Inventory,
                Description = s.Description,
                ImgUrl = s.ImgUrl,
                StyleId = s.style.Id,
                StyleName = s.style.Name,
                MediumId = s.medium.Id,
                MediumName = s.medium.Name,
                ArtworkFieldId = s.artworkField.Id,
                ArtworkFieldName = s.artworkField.Name,

            }).ToList();
            return View(model);
        }
        public IActionResult ArtworkPage(int Id)
        {
            SiteGalleryViewModel model = new SiteGalleryViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            var obj = dbSarv.Gallery
            .Include(s => s.artworkField)
            .Include(s => s.medium)
            .Include(s => s.style)
            .Include(s => s.Artist)
            .Where(s => s.Id == Id)
           
            .ToList().Select(s => new GalleryUpdateViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Subject = s.Subject,
                Artist = s.Artist.FirstName + " " + s.Artist.LastName,
                artistid = s.Artist.Id,
                ProduceYear = s.ProduceDate,
                ProduceDate = s.ProduceDate,
                Size = s.Size,
                SoldDate = s.SoldDate,
                Price = s.Price,

                PublishDate = s.PublishDate,
                UploadDate = s.UploadDate,
                Inventory = s.Inventory,
                Description = s.Description,
                ImgUrl = s.ImgUrl,
                StyleId = s.style.Id,
                StyleName = s.style.Name,
                MediumId = s.medium.Id,
                MediumName = s.medium.Name,
                ArtworkFieldId = s.artworkField.Id,
                ArtworkFieldName = s.artworkField.Name,


            }).ToList().FirstOrDefault();
            if (obj == null)
                return Redirect("/");
            model.gallery = obj;

            return View(model);
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
            ContactViewModel model = new ContactViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            return View();
        }

        private List<HistoryViewModel>? getOrderList()
        {
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            if (UserIsLogin())
            {
                return dbSarv.OrderDetailes
                   .Include(s => s.order)
                   .Include(s => s.order.user)
                   .Include(s => s.gallery)
                   .Include(s => s.gallery.Artist)
                   .Where(s => s.order.isBuy == false && s.order.user != null && s.order.user.Id == CurrentUserId)
                   .ToList().Select(s => new HistoryViewModel
                   {
                       Id = s.Id,
                       ArtistName = s.gallery.Artist.FirstName + " " + s.gallery.Artist.LastName,
                       Artistid = s.gallery.Artist.Id,
                       imgurl = s.gallery.ImgUrl,
                       customerName = s.order.user.FirstName + " " + s.order.user.LastName,
                       customerId = s.order.user.Id,
                       galleryTitle = s.gallery.Title,
                       galleryid = s.gallery.Id,
                       soldDate = s.order.buyDate,
                       Address = s.order.Address ?? "",
                       unitNumber = s.order.UnitNumber ?? "",
                       State = s.order.State ?? "",
                       Price = s.price,
                       Email = s.order.user.Email,
                       City = s.order.City ?? "",
                       postalCode = s.order.PortfolioUrl ?? ""


                   }).ToList();
            }
            return new List<HistoryViewModel>();
        }

        private bool UserIsLogin()
        {
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            return dbSarv.Users.Any(s => s.Id == CurrentUserId);
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
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
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
                LoginUser(artist.Id);

                return Redirect("/");
            }
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            return View(model);


        }
        public IActionResult Signin()
        {
            SigninViewModel model = new SigninViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Signin(SigninViewModel model)
        {
            User? user = dbSarv.Users.Include(s => s.RoleUsers).FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);
            if (user != null)
            {
                LoginUser(user.Id);
                if (dbSarv.RoleUser.Include(s => s.User_).Include(s => s.Role_).Any(s => s.Role_.Id == RoleValues.Admin && s.User_.Id == user.Id))
                {
                    return Redirect("/Profile");
                }
                return Redirect("/");
            }
            ViewBag.Error = "Email or Password incorrect.";
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            return View(model);
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
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "There is an error in record information";
            //    return View();
            //}
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
            LoginUser(newAccount.Id);
            return Redirect("/");

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