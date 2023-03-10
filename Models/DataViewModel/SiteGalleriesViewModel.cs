using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteGalleriesViewModel : SiteMasterViewModel
    {

        public List<int> lstlikeGallery { get; set; }
        public List<GalleryUpdateViewModel> lstGallery { get; set; }



    }
}
