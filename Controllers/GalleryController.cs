using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class GalleryController : AdminMasterController
    {
        public GalleryController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }
        public IActionResult Index()
        {
            List <GalleryViewModel> gallery = db.Gallery
            .Include(s => s.artworkField)
            .Include(s => s.medium)
            .Include(s => s.style)
            .ToList().Select(s => new GalleryViewModel
        {
            Id = s.Id,
            Title= s.Title,
            Subject=s.Subject,
            Artist= s.Artist,
            ProduceYear = s.ProduceYear,
            Size = s.Size,
            SoldDate= s.SoldDate,
            Price= s.Price,
            Availability= s.Availability,
            PublishDate= s.PublishDate,
            UploadDate= s.UploadDate,
            Inventory= s.Inventory,
            Description = s.Description,
            ImgUrl = s.ImgUrl,
            StyleId = s.style == null ? (int?)null : s.style.Id,
            StyleName = s.style == null ? ("") : s.style.Name,
            MediumId = s.medium == null ? (int?)null : s.medium.Id,
            MediumName = s.medium == null ? ("") : s.medium.Name,
            ArtworkFieldId = s.artworkField == null ? (int?)null : s.artworkField.Id,
            ArtworkFieldName = s.artworkField == null ? ("") : s.artworkField.Name,

        }).ToList();
       
            return View(gallery);
        }
        public IActionResult New()
        {
            GalleryViewModel galleryViewModel = new GalleryViewModel();
            return View(galleryViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(AboutViewModel galleryViewModel)
        {
            if (galleryViewModel.UploadImgUrl == null)
            {
                ViewBag.Error = "Image File is mandatory";
                return View(galleryViewModel);
            }
            //   if (ModelState.IsValid)
            {
                Gallery newGallery = new Gallery();
                db.Gallery.Add(newGallery);
                newGallery.Title = galleryViewModel.Title;
                newGallery.Description = galleryViewModel.Description;

              
                //newAboutUs.Team_ = db.Gallery.FirstOrDefault(s => s.Id == TeamViewModel.TeamId);
                newGallery.ImgUrl = await UploadImg(galleryViewModel.UploadImgUrl, "Gallery");
                db.SaveChanges();
                return Redirect("/Gallery");

            }
            // return View(aboutViewModel);

        }
        public IActionResult Delete(int Id)
        {
            Gallery gallery = db.Gallery.FirstOrDefault(s => s.Id == Id);
            if (gallery != null)
            {
                db.Gallery.Remove(gallery);
                db.SaveChanges();
            }
            return Redirect("/about");

        }
    }
}
