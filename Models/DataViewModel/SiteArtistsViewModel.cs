using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteArtistsViewModel : SiteMasterViewModel
    {

        public List<CustomerUpdateViewModel> artists { get; set; }
        public List<string> alphabete { get; set; }


    }
}
