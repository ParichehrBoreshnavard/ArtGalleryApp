using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class CustomerController : AdminMasterController
    {
        public CustomerController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            List<CustomerUpdateViewModel> artist = db.Users.Include(s => s.ArtistField_)
                .Include(s => s.RoleUsers)
                .Where(s => s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Customer))
                .ToList().Select(s => new CustomerUpdateViewModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Description = s.Description,
                    Country = s.Country,
                    ImgUrl = s.ImgUrl,
                    YearOfBirth = s.YearOfBirth,
                    Email = s.Email,
                    Phone = s.Phone,
                    ArtistFieldId = s.ArtistField_ == null ? (int?)null : s.ArtistField_.Id,
                    ArtistFieldName = s.ArtistField_ == null ? ("") : s.ArtistField_.Name,

                }).ToList();
            return View(artist);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            CustomerViewModel obj = new CustomerViewModel();
            obj.lstArtistField = db.ArtistField_.ToList();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(CustomerViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? obj = new User();
                if (obj != null)
                {
                    db.Users.Add(obj);
                    obj.FirstName = model.FirstName;
                    obj.LastName = model.LastName;
                    obj.Description = model.Description;
                    obj.Country = model.Country;
                    obj.YearOfBirth = model.YearOfBirth;
                    obj.Email = model.Email;
                    obj.Phone = model.Phone;
                    obj.Password = model.Password;
                    obj.PortfolioUrl = model.PortfolioUrl;
                    obj.ArtistField_ = model.ArtistFieldId == null ? null : db.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                    if (model.UploadImgUrl != null)
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Customer");

                    RoleUser roleUser = new RoleUser();
                    db.RoleUser.Add(roleUser);
                    roleUser.User_ = obj;
                    roleUser.Role_ = db.Rols.First(s => s.Id == RoleValues.Customer);

                    db.SaveChanges();
                }
                

            }
            return Redirect("/Customer");
            // return View(event_ViewModel);

        }
        public IActionResult Update(int Id)
        {
            ViewBag.Role = setRole();
            CustomerUpdateViewModel? obj = db.Users.Include(s => s.ArtistField_)
                 .Include(s => s.RoleUsers)
                 .Where(s => s.Id == Id && s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Customer))
                 .ToList().Select(s => new CustomerUpdateViewModel
                 {
                     Id = s.Id,
                     FirstName = s.FirstName,
                     LastName = s.LastName,
                     Description = s.Description,
                     Country = s.Country,
                     ImgUrl = s.ImgUrl,
                     YearOfBirth = s.YearOfBirth,
                     Email = s.Email,
                     PortfolioUrl = s.PortfolioUrl,
                     Phone = s.Phone,
                     ArtistFieldId = s.ArtistField_ == null ? (int?)null : s.ArtistField_.Id,
                     ArtistFieldName = s.ArtistField_ == null ? ("") : s.ArtistField_.Name,

                 }).ToList().FirstOrDefault();
            if (obj == null)
            {
                return Redirect("/Customer");
            }
            obj.lstArtistField = db.ArtistField_.ToList();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CustomerUpdateViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? obj = db.Users.FirstOrDefault(s => s.Id == model.Id);
                if (obj != null)
                {
                    obj.FirstName = model.FirstName;
                    obj.LastName = model.LastName;
                    obj.Description = model.Description;
                    obj.Country = model.Country;
                    obj.YearOfBirth = model.YearOfBirth;
                    //artist.Email = model.Email;
                    obj.Phone = model.Phone;
                    if (model.Password != null)
                        obj.Password = model.Password;
                    obj.PortfolioUrl = model.PortfolioUrl;
                    obj.ArtistField_ = model.ArtistFieldId == null ? null : db.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                    if (model.UploadImgUrl != null)
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Customer");
                    db.SaveChanges();
                }
                return Redirect("/Customer");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            var remove = db.Users.FirstOrDefault(s => s.Id == Id);
            if (remove != null)
            {
                foreach (var roleUser in db.RoleUser.Where(s => s.User_ == remove))
                {
                    db.RoleUser.Remove(roleUser);
                }
                db.Users.Remove(remove);
                db.SaveChanges();
            }
            return Redirect("/Customer");
        }
    }
}
