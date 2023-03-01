using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class ArtworkFieldController : AdminMasterController
    {
        public ArtworkFieldController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
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
