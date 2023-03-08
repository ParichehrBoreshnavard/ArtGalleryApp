using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class ProfileController : AdminMasterController
    {
        public ProfileController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
            
        }
        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin))
            {
                AdminUpdateViewModel? obj = db.Users.Include(s => s.ArtistField_)
                      .Where(s => s.Id == CurrentUserId)
                      .ToList().Select(s => new AdminUpdateViewModel
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
                    return Redirect("/");
                }
                obj.lstArtistField = db.ArtistField_.ToList();

                return View(obj);
            }
            else if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
            {
                return Redirect("/Profile/Artist");
            }
            else if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Customer))
            {
                return Redirect("/Profile/Information");
            }
            return Redirect("/");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AdminUpdateViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? obj = db.Users.FirstOrDefault(s => s.Id == CurrentUserId);
                if (obj != null)
                {
                    model.Email = obj.Email;
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
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "User");
                    db.SaveChanges();
                    model.ImgUrl = obj.ImgUrl;
                    model.statusOfPage = "success";

                }
                model.lstArtistField = db.ArtistField_.ToList();
                return View(model);

            }
            // return View(event_ViewModel);

        }

        public IActionResult Artist()
        {
            ViewBag.Role = setRole();
            if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin))
            {
                return Redirect("/Profile");
            }
            else if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
            {
                ArtistsUpdateViewModel? obj = db.Users.Include(s => s.ArtistField_)
      .Where(s => s.Id == CurrentUserId)
      .ToList().Select(s => new ArtistsUpdateViewModel
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
                    return Redirect("/");
                }
                obj.lstArtistField = db.ArtistField_.ToList();

                return View(obj);

            }
            else if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Customer))
            {
                return Redirect("/Profile/Information");
            }
            return Redirect("/");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Artist(ArtistsUpdateViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? obj = db.Users.FirstOrDefault(s => s.Id == CurrentUserId);
                if (obj != null)
                {
                    model.Email = obj.Email;
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
                    obj.ArtistField_ = db.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                    if (model.UploadImgUrl != null)
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Artist");
                    db.SaveChanges();
                    model.ImgUrl = obj.ImgUrl;
                    model.statusOfPage = "success";

                }
                model.lstArtistField = db.ArtistField_.ToList();
                return View(model);

            }
            // return View(event_ViewModel);

        }


        public IActionResult Information()
        {
            ViewBag.Role = setRole();
            if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin))
            {
                return Redirect("/Profile");
            }
            else if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
            {
                return Redirect("/Profile/Artist");
            }
            else if (lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Customer))
            {
                CustomerUpdateViewModel? obj = db.Users.Include(s => s.ArtistField_)
      .Where(s => s.Id == CurrentUserId)
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
                    return Redirect("/");
                }
                obj.lstArtistField = db.ArtistField_.ToList();

                return View(obj);

            }
            return Redirect("/");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Information(CustomerUpdateViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? obj = db.Users.FirstOrDefault(s => s.Id == CurrentUserId);
                if (obj != null)
                {
                    model.Email = obj.Email;
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
                    obj.ArtistField_ =model.ArtistFieldId==null?null: db.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                    if (model.UploadImgUrl != null)
                        obj.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Customer");
                    db.SaveChanges();
                    model.ImgUrl = obj.ImgUrl;
                    model.statusOfPage = "success";

                }
                model.lstArtistField = db.ArtistField_.ToList();
                return View(model);

            }
            // return View(event_ViewModel);

        }
        public IActionResult Logout()
        {
            ViewBag.Role = setRole();
            LogoutUser();
            return Redirect("/");

        }
    }
}
