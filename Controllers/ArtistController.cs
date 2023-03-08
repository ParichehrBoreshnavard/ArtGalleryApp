using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ArtGalleryApp.Controllers
{
    public class ArtistController : AdminMasterController
    {
        public ArtistController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
           
        }

        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            List<ArtistsViewModel> artist = db.Users.Include(s => s.ArtistField_)
                .Include(s => s.RoleUsers)
                .Where(s => s.RoleUsers.Any(t=>t.Role_.Id == RoleValues.Artist))
                .ToList().Select(s => new ArtistsViewModel{
                Id = s.Id,
                FirstName= s.FirstName,
                LastName= s.LastName,
                Description= s.Description,
                Country= s.Country, 
                ImgUrl= s.ImgUrl,
                YearOfBirth= s.YearOfBirth,
                Email= s.Email,
                Phone= s.Phone,
                ArtistFieldId = s.ArtistField_==null?(int?)null:s.ArtistField_.Id,
                ArtistFieldName = s.ArtistField_ == null?(""):s.ArtistField_.Name,

            }).ToList();
            return View(artist);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            ArtistsViewModel artist = new ArtistsViewModel();
            artist.lstArtistField = db.ArtistField_.ToList();
            return View(artist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ArtistsViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? artist = new User();
                if (artist != null)
                {
                    db.Users.Add(artist);
                    artist.FirstName = model.FirstName;
                    artist.LastName = model.LastName;
                    artist.Description = model.Description;
                    artist.Country = model.Country;
                    artist.YearOfBirth = model.YearOfBirth;
                    artist.Email = model.Email;
                    artist.Phone = model.Phone;
                    artist.Password = model.Password;
                    artist.PortfolioUrl = model.PortfolioUrl;
                    artist.ArtistField_ = db.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                    if (model.UploadImgUrl != null)
                        artist.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Artist");

                    RoleUser roleUser = new RoleUser();
                    db.RoleUser.Add(roleUser);
                    roleUser.User_ = artist;
                    roleUser.Role_ = db.Rols.First(s => s.Id == RoleValues.Artist);

                    db.SaveChanges();
                }
                return Redirect("/Artist");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Update(int Id)
        {
            ViewBag.Role = setRole();
            ArtistsUpdateViewModel? artist = db.Users.Include(s => s.ArtistField_)
                 .Include(s => s.RoleUsers)
                 .Where(s => s.Id == Id && s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Artist))
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
            if(artist == null)
            {
                return Redirect("/Artist");
            }
            artist.lstArtistField = db.ArtistField_.ToList();
            return View(artist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ArtistsUpdateViewModel model)
        {
            ViewBag.Role = setRole();
            //if (event_ViewModel.UploadAboutImgUrl == null || event_ViewModel.UploadPosterImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(event_ViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                User? artist = db.Users.FirstOrDefault(s => s.Id == model.Id);
                if (artist != null)
                {
                    artist.FirstName = model.FirstName;
                    artist.LastName = model.LastName;
                    artist.Description = model.Description;
                    artist.Country = model.Country;
                    artist.YearOfBirth = model.YearOfBirth;
                    //artist.Email = model.Email;
                    artist.Phone = model.Phone;
                    if(model.Password != null)
                        artist.Password = model.Password;
                    artist.PortfolioUrl = model.PortfolioUrl;
                    artist.ArtistField_ = db.ArtistField_.FirstOrDefault(s => s.Id == model.ArtistFieldId);
                    if (model.UploadImgUrl != null)
                        artist.ImgUrl = await UploadImg(model.UploadImgUrl, "Users", "Artist");
                    db.SaveChanges();
                }
                return Redirect("/Artist");

            }
            // return View(event_ViewModel);

        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            var remove = db.Users.FirstOrDefault(s => s.Id == Id);
            if (remove != null)
            {
                foreach(var roleUser in db.RoleUser.Where(s=>s.User_ == remove))
                {
                    db.RoleUser.Remove(roleUser);
                }
                db.Users.Remove(remove);
                db.SaveChanges();
            }
            return Redirect("/Artist");
        }
    }
}
