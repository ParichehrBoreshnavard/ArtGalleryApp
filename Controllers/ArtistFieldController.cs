using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers
{
    public class ArtistFieldController : AdminMasterController
    {
        public ArtistFieldController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
            ArtistFieldViewModel artistFieldViewModel = new ArtistFieldViewModel();


            artistFieldViewModel.lstArtistField = db.ArtistFields.Select(s => new ArtistFieldViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return View(artistFieldViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ArtistFieldViewModel artistFieldViewModel)
        {

            //   if (ModelState.IsValid)
            {
                ArtistField newArtistField = new ArtistField();
                db.ArtistFields.Add(newArtistField);
                newArtistField.Name = artistFieldViewModel.Name;
                db.SaveChanges();
                return Redirect("/ArtistField");

            }
            // return View(bannersViewModel);

        }

        public IActionResult Delete(int Id)
        {
            var artistFieldName = db.ArtistFields.FirstOrDefault(s => s.Id == Id);
            if (artistFieldName != null)
            {
                db.ArtistFields.Remove(artistFieldName);
                db.SaveChanges();
            }
            return Redirect("/ArtistField");
        }
    }

}
