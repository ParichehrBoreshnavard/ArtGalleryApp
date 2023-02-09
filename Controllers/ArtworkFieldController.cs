//using ArtGalleryApp.Context;
//using ArtGalleryApp.Models.Data;
//using ArtGalleryApp.Models.DataViewModel;
//using Microsoft.AspNetCore.Mvc;

//namespace ArtGalleryApp.Controllers
//{
//    public class ArtworkFieldController : AdminMasterController
//    {
//        public ArtworkFieldController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
//        {
//        }

//        public IActionResult Index()
//        {
//            //read data from artworkFieldViewModel Then make the information to artworkField db in artworkFieldViewModel Format
//            //, and read From db and assign information to new list;
//            ArtworkFieldController artworkFieldViewModel = new ArtworkFieldViewModel();

//            ArtworkFieldViewModel.lstArtworkField = db.ArtworkFields.Select(s => new ArtworkFieldViewModel

//            {
//                Id = s.Id,
//                Name = s.Name
//            }).ToList();

//            return View(ArtworkFieldViewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Index(ArtworkFieldViewModel artworkFieldViewModel)
//        {

//            //   if (ModelState.IsValid)
//            {
//                ArtworkField newArtworkField = new ArtworkField();
//                db.ArtworkFields.Add(newArtworkField);
//                newArtworkField.Name = artworkFieldViewModel.Name;
//                db.SaveChanges();
//                return Redirect("/ArtworkField");

//            }
//            // return View(bannersViewModel);

//        }

//        public IActionResult Delete(int Id)
//        {
//            var artworkFieldName = db.ArtworkFields.FirstOrDefault(s => s.Id == Id);
//            if (artworkFieldName != null)
//            {
//                db.ArtworkFields.Remove(artworkFieldName);
//                db.SaveChanges();
//            }
//            return Redirect("/ArtworkField");
//        }
//    }
  
//}
