using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers

{
    public class MediumController : AdminMasterController
    {
        public MediumController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
            //read data from mediumViewModel Then make the information to medium db in mediumViewModel Format
            //, and read From db and assign information to new list;
            MediumViewModel mediumViewModel = new MediumViewModel();

            mediumViewModel.lstMedium = db.Mediums.Select(s => new MediumViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return View(mediumViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MediumViewModel mediumViewModel)
        {

            //   if (ModelState.IsValid)
            {
                Medium newMedium = new Medium();
                db.Mediums.Add(newMedium);
                newMedium.Name = mediumViewModel.Name;
                db.SaveChanges();
                return Redirect("/Medium");

            }
           

        }

        public IActionResult Delete(int Id)
             
            {
            var mediumName = db.Mediums.FirstOrDefault(s => s.Id == Id);
            if (mediumName != null)
            {
                db.Mediums.Remove(mediumName);
                db.SaveChanges();
            }
            return Redirect("/Medium");
        }
    }
}

