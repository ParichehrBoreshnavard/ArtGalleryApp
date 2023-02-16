using ArtGalleryApp.Context;
using ArtGalleryApp.Models.Data;
using ArtGalleryApp.Models.DataViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ArtGalleryApp.Controllers
{
    public class ArtistController : AdminMasterController
    {
        public ArtistController(dbSarvContext _db, IWebHostEnvironment webHostEnvironment) : base(_db, webHostEnvironment)
        {
        }

        public IActionResult Index()
        {
            List<ArtistsViewModel> artist = db.Artists.Include(s => s.ArtistField_).ToList().Select(s => new ArtistsViewModel{
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
            ArtistsViewModel artist = new ArtistsViewModel();
            artist.lstArtistField = db.ArtistField_.ToList();
            return View(artist);
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
