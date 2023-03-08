using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryApp.Controllers

{
    public class StyleController : AdminMasterController
    {
        public StyleController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
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
            ViewBag.Role = setRole();
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
            ViewBag.Role = setRole();
            var styleName = db.Styles.FirstOrDefault(s=>s.Id == Id);
            if (styleName != null) {
            db.Styles.Remove(styleName);
                db.SaveChanges();
                    }
            return Redirect("/Style");
        }
    }
}

