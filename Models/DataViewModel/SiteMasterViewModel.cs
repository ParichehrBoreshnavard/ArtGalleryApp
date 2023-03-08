using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace ArtGalleryApp.Models.DataViewModel
{
    public class SiteMasterViewModel
    {
        public bool islogin { get; set; } = false;
        public List<HistoryViewModel>? orderlist { get; set; }
        public List<BannersUpdateViewModel> lstEventMenu { get; set; }
    }
}