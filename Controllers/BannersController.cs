using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class BannersController : AdminMasterController
    {
        public BannersController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            //read data from bannersViewModel Then make the information to banners db in bannersViewModel Format
            //, and read From db and assign information to new list;

            List<BannersViewModel> banners = db.Banners.Include(s=>s.Event_).Select(s => new BannersViewModel {
                Id = s.Id,
                ImgUrl = s.ImgUrl,
                SubDescription = s.SubDescription,
                EventTitle = s.Event_ == null ? "" : s.Event_.Title,
                PublishEndDate = s.PublishEndDate,
                PublishStartDate = s.PublishStartDate,
                Title = s.Title
            }).ToList();

            return View(banners);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            BannersViewModel bannersViewModel = new BannersViewModel();
            bannersViewModel.lstEvent = db.Events_.Where(s=>s.EndDate>=DateTime.Now).ToList(); 
            return View(bannersViewModel);
        

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New( BannersViewModel bannersViewModel)
        {
            ViewBag.Role = setRole();
            if (bannersViewModel.UploadImgUrl == null)
            {
                ViewBag.Error = "Image File is mandatory";
                return View(bannersViewModel);
            }
            //   if (ModelState.IsValid)
            {
                Banner newBanner= new Banner();
                db.Banners.Add(newBanner);
                newBanner.Title= bannersViewModel.Title;
                newBanner.SubDescription= bannersViewModel.SubDescription;
                newBanner.PublishStartDate= bannersViewModel.PublishStartDate;
                newBanner.PublishEndDate= bannersViewModel.PublishEndDate;
                newBanner.Event_ = bannersViewModel.EventId == null ? null : db.Events_.FirstOrDefault(s => s.Id == bannersViewModel.EventId);
                newBanner.ImgUrl= await UploadImg(bannersViewModel.UploadImgUrl,"Banners");
                db.SaveChanges();
                return Redirect("/Banners");

            }
           // return View(bannersViewModel);

        }
        public IActionResult Update(int Id )
        {
            ViewBag.Role = setRole();
            BannersUpdateViewModel? bannersViewModel = db.Banners.Where(s => s.Id == Id)
                .Select(s => new BannersUpdateViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImgUrl = s.ImgUrl,
                    PublishEndDate = s.PublishEndDate,
                    PublishStartDate = s.PublishStartDate,
                    SubDescription = s.SubDescription,
                    EventId = s.Event_ == null ? (int?)null : s.Event_.Id
                }).ToList().FirstOrDefault();
            if (bannersViewModel == null)
                return Redirect("/Banners");
            bannersViewModel.lstEvent =  db.Events_.Where(s => s.EndDate >= DateTime.Now||s.Id == bannersViewModel.EventId).ToList();
            
            return View(bannersViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BannersUpdateViewModel bannersViewModel)
        {
            ViewBag.Role = setRole();
            //if (bannersViewModel.UploadImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(bannersViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                Banner newBanner = db.Banners.First(s => s.Id == bannersViewModel.Id);
                
                newBanner.Title = bannersViewModel.Title;
                newBanner.SubDescription = bannersViewModel.SubDescription;
                newBanner.PublishStartDate = bannersViewModel.PublishStartDate;
                newBanner.PublishEndDate = bannersViewModel.PublishEndDate;
                newBanner.Event_ = bannersViewModel.EventId ==null?(Event_?)null:db.Events_.FirstOrDefault(s => s.Id == bannersViewModel.EventId);
                if(bannersViewModel.UploadImgUrl!=null)
                    newBanner.ImgUrl = await UploadImg(bannersViewModel.UploadImgUrl, "Banners");
                db.SaveChanges();
                return Redirect("/Banners");

            }
            // return View(bannersViewModel);

        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            Banner removeBanner = db.Banners.First(s => s.Id == Id);
            if(removeBanner != null)
            {
                db.Banners.Remove(removeBanner);
                db.SaveChanges();
            }
            return Redirect("/Banners");
        }
    }
}
