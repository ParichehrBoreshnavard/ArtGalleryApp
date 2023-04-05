using ArtGalleryApp.Context;
using ArtGalleryApp.Models;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Humanizer.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PayPal.Api;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using Order = ArtGalleryApp.Models.Data.Order;

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

            SiteMasterViewModel model = new SiteMasterViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Basket(int Id, string btn)
        {
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            SiteMasterViewModel model = new SiteMasterViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            if (btn == "Remove")
            {
                var obj = dbSarv.OrderDetailes.Include(s => s.order).FirstOrDefault(x => x.Id == Id);
                if (obj != null)
                {
                    var cart = dbSarv.Orders.First(s => s.Id == obj.order.Id);
                    cart.orderPrice -= obj.price;
                    if (cart.orderPrice < 0)
                    {
                        cart.orderPrice = 0;
                    }
                    dbSarv.OrderDetailes.Remove(obj);
                    dbSarv.SaveChanges();
                }
                model.orderlist = getOrderList();
            }
            return View(model);
        }

        private PayPal.Api.Payment payment;



        public IActionResult Checkout()
        {
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            SiteCheckoutViewModel model = new SiteCheckoutViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();

            if (model.orderlist == null || !model.orderlist.Any())
            {
                return Redirect("/Home/Basket");
            }
            model.user_ = dbSarv.Users.Include(s => s.ArtistField_)

                 .Where(s => s.Id == CurrentUserId)
                 .ToList().Select(s => new CustomerUpdateViewModel
                 {
                     Id = s.Id,
                     FirstName = s.FirstName,
                     LastName = s.LastName,
                     Description = s.Description,
                     Country = s.Country,
                     ImgUrl = s.ImgUrl,
                     YearOfBirth = s.YearOfBirth,
                     Email = s.Email,
                     PortfolioUrl = s.PortfolioUrl,
                     Phone = s.Phone,
                     ArtistFieldId = s.ArtistField_ == null ? (int?)null : s.ArtistField_.Id,
                     ArtistFieldName = s.ArtistField_ == null ? ("") : s.ArtistField_.Name,

                 }).ToList().First();
            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(SiteCheckoutViewModel model)
        {
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            var cart = dbSarv.Orders.Include(s => s.user).FirstOrDefault(s => s.isBuy == false &&s.user!=null&& s.user.Id == CurrentUserId);
            if(cart==null)
            {
                return Redirect("/Home/Checkout");
            }

            
            cart.Address = model.address;
            cart.State = model.state;
            cart.PortfolioUrl = model.zip;
            dbSarv.SaveChanges();
            return PaymentWithPaypal();
        }

        public IActionResult PaymentWithPaypal(string Cancel = null, string blogId = "", string _payerId = "", string guidId = "")
        {
            var clientID = "ASzzj_ATvoYAVyimR0Mb-tcj9ILN1SgqEdHLFmAPCE8P1rJRzXVA6i1fv34chi7F-BmxFD8R__T1HW2e";
            var clientScret = "EDLaCo-7r6s_M73RI_51FkOZGJHefxzS0s7GqyOf2WhuvGR9dVOY57zoPhva3w268G9rQQA079oBchFn";
            var mode = "sandbox";
            APIContext aPIContext = PayPalConfiguration.GetAPIContext(clientID, clientScret, mode);
            try
            {
                string payerId = _payerId;
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseUrl = this.Request.Scheme + "://" + this.Request.Host + "/Home/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    guidId = guid;
                    var createPayment = CreatePayment(aPIContext, baseUrl + "guid=" + guid, blogId);
                    var links = createPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    HttpContext.Session.SetString("paymentid", createPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var paymentId = HttpContext.Session.GetString("paymentid");
                    var executepayment = ExecutePayment(aPIContext, payerId, paymentId);
                    if (executepayment.state.ToLower() != "approved")
                    {
                        SiteMasterViewModel obj = new SiteMasterViewModel();
                        obj.islogin = UserIsLogin();
                        obj.orderlist = getOrderList();
                        obj.lstEventMenu = getMenuList();
                        return View("PaymentFaield", obj);
                    }
                    int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;

                    var cart = dbSarv.Orders.Include(s => s.user).First(s => s.Id.ToString() == executepayment.transactions.First().invoice_number);
                    cart.isBuy = true;
                    dbSarv.SaveChanges();

                    SiteMasterViewModel model = new SiteMasterViewModel();
                    model.islogin = UserIsLogin();
                    model.orderlist = getOrderList();
                    model.lstEventMenu = getMenuList();
                    return View("PaymentSuccess", model);

                }
            }
            catch
            {


            }
            SiteMasterViewModel obj1 = new SiteMasterViewModel();
            obj1.islogin = UserIsLogin();
            obj1.orderlist = getOrderList();
            obj1.lstEventMenu = getMenuList();
            return View("PaymentFaield", obj1);
        }
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecurion = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecurion);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string blogid)
        {
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            var model = getOrderList();
            var orderid = dbSarv.Orders.Include(s => s.user).Where(s => s.isBuy == false && s.user.Id == CurrentUserId).First().Id;

            var item_list = new ItemList()
            {
                items = new List<Item>()
            };
            foreach (var item in model)
            {
                item_list.items.Add(new Item()
                {
                    name = item.galleryTitle,
                    currency = "USD",
                    price = item.Price.ToString("#.00"),
                    quantity = "1",
                    sku = "SKU"
                });
            }
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "Cancel=true",
                return_url = redirectUrl
            };
            Amount amount = new Amount()
            {
                currency = "USD",
                total = model.Sum(s => s.Price).ToString("#.00")
            };
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "App Gallery",
                invoice_number = orderid.ToString(),
                amount = amount,
                item_list = item_list
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return payment.Create(apiContext);
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
            SiteBlogsGalleriesViewModel model = new SiteBlogsGalleriesViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            model.lst = dbSarv.Blogs.OrderByDescending(s => s.WrittenDate).Select(s => new BlogUpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgDescription = s.ImgDescription,
                ImgUrl = s.ImgUrl,
                Article = s.Article,
                Summary = s.Summary,
                Author = s.Author,
                WrittenDate = s.WrittenDate,




            }).ToList();
            model.first = model.lst.FirstOrDefault();
            if (model.first != null)
                model.lst.Remove(model.first);
            return View(model);
        }
        public IActionResult BlogPage(int Id)
        {
            SiteBlogGalleriesViewModel model = new SiteBlogGalleriesViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            BlogUpdateViewModel? obj = dbSarv.Blogs.Where(s => s.Id == Id).Select(s => new BlogUpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgDescription = s.ImgDescription,
                ImgUrl = s.ImgUrl,
                Article = s.Article,
                Summary = s.Summary,
                Author = s.Author,
                WrittenDate = s.WrittenDate,




            }).ToList().FirstOrDefault();
            if (obj == null)
                return Redirect("/Home/Blog");
            model.blog = obj;
            return View(model);
        }
        //public IActionResult Events()
        //{
        //    return View();
        //}
        public IActionResult Events(int Id)
        {
            SiteEventViewModel model = new SiteEventViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            var obj = dbSarv.Events_.Where(s => s.Id == Id).Select(s => new Event_UpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgUrlAbout = s.ImgUrlAbout,
                ImgUrlPoster = s.ImgUrlPoster,
                Description = s.Description,
                AboutDescription = s.AboutDescription,
                SubEvents = s.SubEvents,
                EndDate = s.EndDate,
                UrlTicketStore = s.UrlTicketStore,
                StartDate = s.StartDate



            }).ToList().FirstOrDefault();
            if (obj == null)
            {
                return Redirect("/");
            }
            model.event_ = obj;
            model.lstsubEvent = dbSarv.SubEvents.Include(s => s.Events_).Where(s => s.Events_.Id == Id).Select(s => new SubEvent_UpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgUrl = s.ImgUrl,
                eventId = s.Events_.Id,
                Description = s.Description,
                eventTitle = s.Events_.Title,
                EndDate = (s.EndDate.HasValue ? s.EndDate.Value : DateTime.Now),
                UrlTicketStore = s.UrlTicketStore,
                StartDate = (s.StartDate.HasValue ? s.StartDate.Value : DateTime.Now)


            }).ToList();
            return View(model);
        }
        public IActionResult Artists()
        {
            SiteArtistsViewModel model = new SiteArtistsViewModel();
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
            model.alphabete.Add("X"); model.alphabete.Add("Y"); model.alphabete.Add("Z");
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
                return Redirect("/Home/Artists");
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
                return Redirect("/Home/Gallery");
            model.gallery = obj;

            return View(model);
        }
        [HttpPost]
        public IActionResult ArtworkPage(int Id, string btn)
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
                return Redirect("/Home/Gallery");

            model.gallery = obj;

            if (btn == "addCart")
            {
                if (!model.islogin)
                {
                    return Redirect("/Home/Signin");
                }
                int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
                var cart = dbSarv.Orders.Include(s => s.user).FirstOrDefault(s => s.user != null && s.user.Id == CurrentUserId && s.isBuy == false);
                if (cart == null)
                {
                    cart = new Order();
                    cart.user = dbSarv.Users.First(s => s.Id == CurrentUserId);
                    cart.isBuy = false;
                    cart.orderPrice = 0;
                    dbSarv.Orders.Add(cart);

                    dbSarv.SaveChanges();
                }
                double temp = 0;
                var item = new OrderDetaile();
                dbSarv.OrderDetailes.Add(item);
                item.gallery = dbSarv.Gallery.First(s => s.Id == Id);
                item.order = cart;
                item.orderDateTime = DateTime.Now;
                item.price = double.TryParse(item.gallery.Price, out temp) ? temp : 0;
                cart.orderPrice += item.price;
                dbSarv.SaveChanges();

            }
            model.orderlist = getOrderList();

            return View(model);
        }
        public IActionResult Gallery()
        {

            SiteGalleriesViewModel model = new SiteGalleriesViewModel();
            model.islogin = UserIsLogin();
            model.orderlist = getOrderList();
            model.lstEventMenu = getMenuList();
            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            model.lstlikeGallery = dbSarv.LikeGalleries.Where(s => s.userId == CurrentUserId)
                .Select(s => s.galleryId).ToList();
            model.lstGallery = dbSarv.Gallery
                .Include(s => s.artworkField)
                .Include(s => s.medium)
                .Include(s => s.style)
                .Include(s => s.Artist)
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
        [HttpPost]
        public JsonResult LikeGallery(int id)
        {

            int CurrentUserId = HttpContext.Session.GetInt32("artGalleryuserid") ?? 0;
            string _status = "";
            try
            {
                var like = dbSarv.LikeGalleries.FirstOrDefault(s => s.userId == CurrentUserId && s.galleryId == id);
                if (like == null)
                {
                    dbSarv.LikeGalleries.Add(new LikeGallery() { userId = CurrentUserId, galleryId = id });
                    _status = "ADD";
                }
                else
                {
                    dbSarv.LikeGalleries.Remove(like);
                    _status = "REMOVE";
                }
                dbSarv.SaveChanges();
            }
            catch
            {
                _status = "";
            }
            return Json(new { status = _status });
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
            return View(model);
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
                   .Include(s => s.gallery.style)
                   .Include(s => s.gallery.medium)
                   .Include(s => s.gallery.artworkField)
                   .Include(s => s.gallery.Artist.ArtistField_)
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
                       postalCode = s.order.PortfolioUrl ?? "",
                       artistField = s.gallery.Artist.ArtistField_ == null ? "" : s.gallery.Artist.ArtistField_.Name,
                       style = s.gallery.style.Name,
                       Medium = s.gallery.medium.Name,
                       artworkField = s.gallery.artworkField.Name,

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