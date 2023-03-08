using ArtGalleryApp.Context;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class FavoritesController : AdminMasterController
    {
        public FavoritesController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }
        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            List<HistoryViewModel> lst = db.LikeGalleries
           .Include(s => s.gallery)
           .Include(s => s.user)
           .ToList().Select(s => new HistoryViewModel
           {
               Id = s.Id,
               ArtistName = s.user == null ? "-" : (s.user.FirstName + " " + s.user.LastName),
               Artistid = s.user == null ? 0 : s.user.Id,
               imgurl = s.gallery.ImgUrl,
               customerName = "",
               customerId = 0,
               galleryTitle = s.gallery.Title,
               galleryid = s.gallery.Id,
               soldDate = DateTime.Now,
               Address = "",
               unitNumber = "",
               State = "",
               Price = 0,
               Email = s.user == null ? "" : s.user.Email,
               City = "",
               postalCode = ""


           }).ToList();

            lst = lst.Where(s => s.Artistid == CurrentUserId).ToList();

            return View(lst);

        }
    }
}
