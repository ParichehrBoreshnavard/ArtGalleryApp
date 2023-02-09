using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers

{
    public class StyleController : AdminMasterController
    {
        public StyleController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
            //read data from styleViewModel Then make the information to style db in styleViewModel Format
            //, and read From db and assign information to new list;
            StyleViewModel styleViewModel= new StyleViewModel();

            styleViewModel.lstStyle = db.Styles.Select(s => new StyleViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return View(styleViewModel);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(StyleViewModel styleViewModel)
        {

            //   if (ModelState.IsValid)
            {
                Style newStyle = new Style();
                db.Styles.Add(newStyle);
                newStyle.Name = styleViewModel.Name;
                db.SaveChanges();
                return Redirect("/Style");

            }
            // return View(bannersViewModel);

        }
     
        public IActionResult Delete(int Id)
        {
            var styleName = db.Styles.FirstOrDefault(s=>s.Id == Id);
            if (styleName != null) {
            db.Styles.Remove(styleName);
                db.SaveChanges();
                    }
            return Redirect("/Style");
        }
    }
}

