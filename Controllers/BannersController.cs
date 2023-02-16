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
        public BannersController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
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
            BannersViewModel bannersViewModel = new BannersViewModel();
            bannersViewModel.lstEvent = db.Events_.Where(s=>s.EndDate>=DateTime.Now).ToList(); ;
            return View(bannersViewModel);
        

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New( BannersViewModel bannersViewModel)
        {
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
                newBanner.Event_ = db.Events_.FirstOrDefault(s => s.Id == bannersViewModel.EventId);
                newBanner.ImgUrl= await UploadImg(bannersViewModel.UploadImgUrl,"Banners");
                db.SaveChanges();
                return Redirect("/Banners");

            }
           // return View(bannersViewModel);

        }
        public IActionResult Update(int Id )
        {
            return View();
        }
        public IActionResult Delete(int Id)
        {
            return View(); 
        }
    }
}
