using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteCheckoutViewModel : SiteMasterViewModel
    {

        public CustomerUpdateViewModel? user_ { get; set; }

        public string address { get; set; } = "";
        public string state { get; set; } = "";
        public string zip { get; set; } = "";

    }
}
