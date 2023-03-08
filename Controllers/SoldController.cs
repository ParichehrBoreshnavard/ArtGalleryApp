using ArtGalleryApp.Context;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class SoldController : AdminMasterController
    {
        public SoldController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }
        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            return Redirect("/Sold/History");
        }
        public IActionResult History()
        {
            ViewBag.Role = setRole();
            List<HistoryViewModel> lst = db.OrderDetailes
           .Include(s => s.order)
           .Include(s => s.order.user)
           .Include(s => s.gallery)
           .Include(s => s.gallery.Artist)
           .Where(s=>s.order.isBuy == true)
           .ToList().Select(s => new HistoryViewModel
           {
               Id = s.Id,
               ArtistName = s.gallery.Artist.FirstName+" "+s.gallery.Artist.LastName,
               Artistid=s.gallery.Artist.Id,
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
               City =s.order.City??"",
               postalCode =s.order.PortfolioUrl??""


           }).ToList();
            if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) )
            {
                lst = lst.Where(s => s.Artistid == CurrentUserId).ToList();
            }
            return View(lst);
            
        }

        public IActionResult HistoryDetail(int Id)
        {
            ViewBag.Role = setRole();
            HistoryViewModel? obj = db.OrderDetailes
           .Include(s => s.order)
           .Include(s => s.order.user)
           .Include(s => s.gallery)
           .Include(s => s.gallery.Artist)
           .Where(s => s.order.isBuy == true && s.Id== Id)
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


           }).ToList().FirstOrDefault();
            if(obj==null)
            {
                return Redirect("/Sold/History");
            }
            if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) )
            {
                if(obj.Artistid!=CurrentUserId)
                {
                    return Redirect("/Sold/History");
                }
            }
            return View(obj);

        }

    }
}
