using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteArtistViewModel : SiteMasterViewModel
    {

        public CustomerUpdateViewModel artist { get; set; }
        public List<GalleryUpdateViewModel> lstGallery { get; set; }


    }
}
