using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class AboutController : AdminMasterController
    {
        public AboutController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }
        public IActionResult Index()
        {
            ViewBag.Role =setRole();
            AboutViewModel? about = db.About.Select(s => new AboutViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImgUrl = s.ImgUrl
                //lstTeam = s.Team_ == null ? "" : s.Team_.FirstName,

            }).ToList().FirstOrDefault();
            if(about ==null)
            {
                about = new AboutViewModel();
                
            }
            return View(about);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            AboutViewModel aboutViewModel = new AboutViewModel();
            return View(aboutViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AboutViewModel aboutViewModel)
        {
            ViewBag.Role = setRole();
            //if (aboutViewModel.UploadImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(aboutViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                About? newAboutUs = db.About.FirstOrDefault();
                if (newAboutUs == null)
                {
                    newAboutUs = new About();
                    db.About.Add(newAboutUs);

                }
                newAboutUs.Title = aboutViewModel.Title;
                newAboutUs.Description = aboutViewModel.Description;
                //newAboutUs.Team_ = db.Teams.FirstOrDefault(s => s.Id == TeamViewModel.TeamId);
                if (aboutViewModel.UploadImgUrl != null)
                {
                    newAboutUs.ImgUrl = await UploadImg(aboutViewModel.UploadImgUrl, "About");
                }
                db.SaveChanges();

                AboutViewModel about = new AboutViewModel();

                about.Id = newAboutUs.Id;
                about.Title = newAboutUs.Title;
                about.Description = newAboutUs.Description;
                about.ImgUrl = newAboutUs.ImgUrl==null?"": newAboutUs.ImgUrl;
                about.statusOfPage = "success";
               

                return View(about);

            }
            // return View(aboutViewModel);

        }
        public IActionResult Update(int Id)
        {
            ViewBag.Role = setRole();
            return View();
        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            About? about = db.About.FirstOrDefault(s => s.Id == Id);
            if (about != null)
            {
                db.About.Remove(about);
                db.SaveChanges();
            }
                return Redirect("/about");
           
        }
    }
}
