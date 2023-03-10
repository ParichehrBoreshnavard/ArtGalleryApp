using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteBlogsGalleriesViewModel : SiteMasterViewModel
    {

        public BlogUpdateViewModel? first { get; set; }
        public List<BlogUpdateViewModel> lst { get; set; }



    }
}
