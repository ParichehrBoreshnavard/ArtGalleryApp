using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtGalleryApp.Controllers
{
    public class BlogController : AdminMasterController
    {
        public BlogController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            //read data from Event_ViewModel Then make the information to event_ db in event_ViewModel Format
            //, and read From db and assign information to new list;

            List<BlogUpdateViewModel> listModel = db.Blogs.Select(s => new BlogUpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgDescription = s.ImgDescription,
                ImgUrl = s.ImgUrl,
                Article = s.Article,
                Summary = s.Summary,
                Author = s.Author,
                WrittenDate = s.WrittenDate,




            }).ToList();

            return View(listModel);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            BlogViewModel model = new BlogViewModel();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(BlogViewModel model)
        {
            ViewBag.Role = setRole();
            if (model.UploadDescriptionUrl == null || model.UploadImgUrl == null)
            {
                model.ErrorMessagePage = "Image File is mandatory";
                model.statusOfPage = "error";
                return View(model);
            }
            //   if (ModelState.IsValid)
            {
                Blog obj = new Blog();
                db.Blogs.Add(obj);
                obj.Title = model.Title;
                obj.Summary = model.Summary;
                obj.Article = model.Article;
                obj.WrittenDate = DateTime.Now;
                obj.Author = model.Author;


                obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Blogs", "Poster");
                obj.ImgDescription = await UploadImg(model.UploadDescriptionUrl, "Blogs", "image");
                db.SaveChanges();
                return Redirect("/Blog");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Update(int Id)
        {
            ViewBag.Role = setRole();
            BlogUpdateViewModel? obj = db.Blogs.Where(s => s.Id == Id).Select(s => new BlogUpdateViewModel
            {

                Id = s.Id,
                Title = s.Title,
                ImgDescription = s.ImgDescription,
                ImgUrl = s.ImgUrl,
                Article = s.Article,
                Summary = s.Summary,
                Author = s.Author,
                WrittenDate = s.WrittenDate,
                



            }).ToList().FirstOrDefault();
            if (obj == null)
                return Redirect("/Blog");

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BlogUpdateViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                Blog? obj = db.Blogs.FirstOrDefault(s => s.Id == model.Id);
                if (obj != null)
                {
                    obj.Title = model.Title;
                    obj.Summary = model.Summary;
                    obj.Article = model.Article;
                    //obj.WrittenDate = DateTime.Now;
                    obj.Author = model.Author;

                    if (model.UploadImgUrl != null)
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Blogs", "Poster");
                    if (model.UploadDescriptionUrl != null)
                        obj.ImgDescription = await UploadImg(model.UploadDescriptionUrl, "Blogs", "image");
                    db.SaveChanges();
                }
                return Redirect("/Blog");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            var remove = db.Blogs.First(s => s.Id == Id);
            if (remove != null)
            {
                db.Blogs.Remove(remove);
                db.SaveChanges();
            }
            return Redirect("/Blog");
        }
    }
}
