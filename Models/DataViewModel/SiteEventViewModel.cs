using ArtGalleryApp.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteEventViewModel : SiteMasterViewModel
    {

        public Event_UpdateViewModel event_ { get; set; }
        public List<SubEvent_UpdateViewModel> lstsubEvent{ get; set; }


    }
}
