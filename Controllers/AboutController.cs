using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class AboutController : AdminMasterController
    {
        public AboutController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }
        public IActionResult Index()
            {
            List<AboutViewModel> about = db.About.Select(s => new AboutViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImgUrl = s.ImgUrl
            }).ToList();

            return View(about);
        }
            public IActionResult New()
            {
                AboutViewModel aboutViewModel = new AboutViewModel();
                return View(aboutViewModel);

            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> New(AboutViewModel aboutViewModel)
            {
                if (aboutViewModel.UploadImgUrl == null)
                {
                    ViewBag.Error = "Image File is mandatory";
                    return View(aboutViewModel);
                }
                //   if (ModelState.IsValid)
                {
                    About newAboutUs = new About();
                    db.About.Add(newAboutUs);
                    newAboutUs.Title = aboutViewModel.Title;
                    newAboutUs.Description = aboutViewModel.Description;
                    newAboutUs.ImgUrl = await UploadImg(aboutViewModel.UploadImgUrl, "About");
                    db.SaveChanges();
                    return Redirect("/About");

                }
                // return View(aboutViewModel);

            }
            public IActionResult Update(int Id)
            {
                return View();
            }
            public IActionResult Delete(int Id)
        {
            return View();
        }
    }
}
