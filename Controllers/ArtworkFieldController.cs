using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class ArtworkFieldController : AdminMasterController
    {
        public ArtworkFieldController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            ArtworkFieldViewModel artworkFieldViewModel = new ArtworkFieldViewModel();

            artworkFieldViewModel.lstArtworkField = db.ArtworkField_.Select(s => new ArtworkFieldViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return View(artworkFieldViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ArtworkFieldViewModel artworkFieldViewModel)
        {
            ViewBag.Role = setRole();
            //   if (ModelState.IsValid)
            {
                ArtworkField newArtworkField = new ArtworkField();
                db.ArtworkField_.Add(newArtworkField);
                newArtworkField.Name = artworkFieldViewModel.Name;
                db.SaveChanges();
                return Redirect("/ArtworkField");

            }
            // return View(bannersViewModel);

        }

        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            var artworkFieldName = db.ArtworkField_.FirstOrDefault(s => s.Id == Id);
            if (artworkFieldName != null)
            {
                db.ArtworkField_.Remove(artworkFieldName);
                db.SaveChanges();
            }
            return Redirect("/ArtworkField");
        }
    }

}
