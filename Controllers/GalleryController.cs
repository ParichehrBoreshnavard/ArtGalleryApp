using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using ArtGalleryApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryApp.Controllers
{
    public class GalleryController : AdminMasterController
    {
        public GalleryController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor _httpContextAccessor) : base(_db, webHostEnvironment, _httpContextAccessor)
        {
        }
        public IActionResult Index()
        {
            ViewBag.Role = setRole();
            List<GalleryViewModel> gallery = db.Gallery
            .Include(s => s.artworkField)
            .Include(s => s.medium)
            .Include(s => s.style)
            .Include(s => s.Artist)
            .ToList().Select(s => new GalleryViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Subject = s.Subject,
                Artist = s.Artist.FirstName + " " + s.Artist.LastName,
                artistid = s.Artist.Id,
                ProduceYear = s.ProduceDate,
                ProduceDate = s.ProduceDate,
                Size = s.Size,
                SoldDate = s.SoldDate,
                Price = s.Price,

                PublishDate = s.PublishDate,
                UploadDate = s.UploadDate,
                Inventory = s.Inventory,
                Description = s.Description,
                ImgUrl = s.ImgUrl,
                StyleId = s.style.Id,
                StyleName = s.style.Name,
                MediumId = s.medium.Id,
                MediumName = s.medium.Name,
                ArtworkFieldId = s.artworkField.Id,
                ArtworkFieldName = s.artworkField.Name,

            }).ToList();
            if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) && lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
            {
                gallery = gallery.Where(s => s.artistid == CurrentUserId).ToList();
            }
            return View(gallery);
        }
        public IActionResult New()
        {
            ViewBag.Role = setRole();
            GalleryViewModel galleryViewModel = new GalleryViewModel();
            galleryViewModel.lstArtworkField = db.ArtworkField_.ToList();
            galleryViewModel.lstMedium = db.Mediums.ToList();
            galleryViewModel.lstStyle = db.Styles.ToList();
            galleryViewModel.lstArtist = db.Users
                .Include(s => s.RoleUsers)
                .Where(s => s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Artist))
                .Select(s => new CustomSelectList() { Id = s.Id, Name = s.FirstName + " " + s.LastName }).ToList();
            if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) && lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
            {
                galleryViewModel.lstArtist = galleryViewModel.lstArtist.Where(s => s.Id == CurrentUserId).ToList();
                galleryViewModel.artistid = CurrentUserId;
            }
            return View(galleryViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(GalleryViewModel galleryViewModel)
        {
            ViewBag.Role = setRole();
            if (galleryViewModel.UploadImgUrl == null)
            {
                ViewBag.Error = "Image File is mandatory";
                return View(galleryViewModel);
            }
            //   if (ModelState.IsValid)
            {
                if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) && lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
                {
                    if (galleryViewModel.artistid != CurrentUserId)
                    {
                        return Redirect("/Gallery");
                    }
                }
                Gallery newGallery = new Gallery();
                db.Gallery.Add(newGallery);
                newGallery.Subject = newGallery.Title = galleryViewModel.Title;
                newGallery.Description = galleryViewModel.Description;
                newGallery.Inventory = galleryViewModel.Inventory.HasValue ? galleryViewModel.Inventory.Value : 0;
                newGallery.medium = db.Mediums.First(s => s.Id == galleryViewModel.MediumId);
                newGallery.style = db.Styles.First(s => s.Id == galleryViewModel.StyleId);
                newGallery.artworkField = db.ArtworkField_.First(s => s.Id == galleryViewModel.ArtworkFieldId);
                newGallery.Artist = db.Users.First(s => s.Id == galleryViewModel.artistid);
                newGallery.UploadDate = DateTime.Now;
                newGallery.ProduceYear = galleryViewModel.ProduceDate;
                newGallery.ProduceDate = galleryViewModel.ProduceDate;
                newGallery.PublishDate = galleryViewModel.PublishDate;

                newGallery.Price = galleryViewModel.Price;
                newGallery.Size = galleryViewModel.Size;

                //newAboutUs.Team_ = db.Gallery.FirstOrDefault(s => s.Id == TeamViewModel.TeamId);
                newGallery.Image = newGallery.ImgUrl = await UploadImg(galleryViewModel.UploadImgUrl, "Gallery", "Gallery");
                db.SaveChanges();
                return Redirect("/Gallery");

            }
            // return View(aboutViewModel);

        }
        public IActionResult Update(int Id)
        {
            ViewBag.Role = setRole();
            GalleryUpdateViewModel? gallery = db.Gallery
            .Include(s => s.artworkField)
            .Include(s => s.medium)
            .Include(s => s.style)
            .Include(s => s.Artist)
            .Where(s => s.Id == Id)
            .ToList().Select(s => new GalleryUpdateViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Subject = s.Subject,
                Artist = s.Artist.FirstName + " " + s.Artist.LastName,
                artistid = s.Artist.Id,
                ProduceYear = s.ProduceDate,
                ProduceDate = s.ProduceDate,
                Size = s.Size,
                SoldDate = s.SoldDate,
                Price = s.Price,

                PublishDate = s.PublishDate,
                UploadDate = s.UploadDate,
                Inventory = s.Inventory,
                Description = s.Description,
                ImgUrl = s.ImgUrl,
                StyleId = s.style.Id,
                StyleName = s.style.Name,
                MediumId = s.medium.Id,
                MediumName = s.medium.Name,
                ArtworkFieldId = s.artworkField.Id,
                ArtworkFieldName = s.artworkField.Name,

            }).ToList().FirstOrDefault();

            if (gallery == null)
            {
                return Redirect("/Gallery");
            }
            gallery.lstArtworkField = db.ArtworkField_.ToList();
            gallery.lstMedium = db.Mediums.ToList();
            gallery.lstStyle = db.Styles.ToList();
            gallery.lstArtist = db.Users
                .Include(s => s.RoleUsers)
                .Where(s => s.RoleUsers.Any(t => t.Role_.Id == RoleValues.Artist))
                .Select(s => new CustomSelectList() { Id = s.Id, Name = s.FirstName + " " + s.LastName }).ToList();
            if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) && lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
            {
                if (gallery.artistid != CurrentUserId)
                {
                    return Redirect("/Gallery");
                }
                gallery.lstArtist = gallery.lstArtist.Where(s => s.Id == CurrentUserId).ToList();

            }
            return View(gallery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GalleryUpdateViewModel galleryViewModel)
        {
            ViewBag.Role = setRole();
            //if (galleryViewModel.UploadImgUrl == null)
            //{
            //    ViewBag.Error = "Image File is mandatory";
            //    return View(galleryViewModel);
            //}
            //   if (ModelState.IsValid)
            {
                Gallery? newGallery = db.Gallery.FirstOrDefault(s => s.Id == galleryViewModel.Id);
                if (newGallery != null)
                {
                    if (!lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Admin) && lstCurrentuserRoles.Any(s => s.Role_.Id == RoleValues.Artist))
                    {
                        if (galleryViewModel.artistid != CurrentUserId)
                        {
                            return Redirect("/Gallery");
                        }
                    }

                    newGallery.Artist = db.Users.First(s => s.Id == galleryViewModel.artistid);
                    newGallery.Subject = newGallery.Title = galleryViewModel.Title;
                    newGallery.Description = galleryViewModel.Description;
                    newGallery.Inventory = galleryViewModel.Inventory.HasValue ? galleryViewModel.Inventory.Value : 0;
                    newGallery.medium = db.Mediums.First(s => s.Id == galleryViewModel.MediumId);
                    newGallery.style = db.Styles.First(s => s.Id == galleryViewModel.StyleId);
                    newGallery.artworkField = db.ArtworkField_.First(s => s.Id == galleryViewModel.ArtworkFieldId);

                    newGallery.UploadDate = DateTime.Now;
                    newGallery.ProduceYear = galleryViewModel.ProduceDate;
                    newGallery.ProduceDate = galleryViewModel.ProduceDate;
                    newGallery.PublishDate = galleryViewModel.PublishDate;

                    newGallery.Price = galleryViewModel.Price;
                    newGallery.Size = galleryViewModel.Size;

                    //newAboutUs.Team_ = db.Gallery.FirstOrDefault(s => s.Id == TeamViewModel.TeamId);
                    if (galleryViewModel.UploadImgUrl != null)
                        newGallery.Image = newGallery.ImgUrl = await UploadImg(galleryViewModel.UploadImgUrl, "Gallery", "Gallery");
                    db.SaveChanges();
                }
                return Redirect("/Gallery");

            }
            // return View(aboutViewModel);

        }
        public IActionResult Delete(int Id)
        {
            ViewBag.Role = setRole();
            Gallery? gallery = db.Gallery.FirstOrDefault(s => s.Id == Id);
            if (gallery != null)
            {
                db.Gallery.Remove(gallery);
                db.SaveChanges();
            }
            return Redirect("/Gallery");

        }
    }
}
